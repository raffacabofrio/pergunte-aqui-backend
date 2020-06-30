using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PergunteAqui.Domain;
using PergunteAqui.Domain.Common;
using PergunteAqui.Domain.Enums;
using PergunteAqui.Domain.Exceptions;
using PergunteAqui.Helper;
using PergunteAqui.Helper.Crypto;
using PergunteAqui.Repository;
using PergunteAqui.Repository.Repository;
using PergunteAqui.Repository.UoW;
using PergunteAqui.Service.Generic;

namespace PergunteAqui.Service
{
    public class QAService : BaseService<Question>, IQAService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ILikeRepository _likeRepository;


        public QAService(IQuestionRepository questionRepository,
            IUnitOfWork unitOfWork,
            IValidator<Question> validator,
            IAnswerRepository answerRepository,
            ILikeRepository likeRepository) : base(questionRepository, unitOfWork, validator)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _likeRepository = likeRepository;
        }

        public IList<Question> GetQuestions(string search = "")
        {
            var query = _questionRepository.Get();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(q => q.Text.Contains(search));

            query = query.OrderByDescending(q => q.totalLikes);

            return query.ToList();
        }

        public Question GetQuestion(Guid id)
        {
            var question = _questionRepository.Find(id);

            if (question == null)
                throw new BizException(BizException.Error.NotFound, "Não encontramos o conteúdo selecionado.");

            return question;
        }

        public void AddQuestion(string text, string user)
        {
            if (BadWordHelper.HasBadWord(text))
                throw new BizException("Tem algum conteúdo indevido na sua pergunta. Por favor revise.");

            var question = new Question()
            {
                Text = text,
                User = user
            };

            _questionRepository.Insert(question);
        }

        public IList<Answer> GetAnswers(Guid questionId)
        {
            return _answerRepository.Get().Where(a => a.QuestionId == questionId)
                .OrderByDescending(a => a.totalLikes).ToList();
        }

        public void AddAnswer(Answer answer)
        {
            if (BadWordHelper.HasBadWord(answer.Text))
                throw new BizException("Tem algum conteúdo indevido na sua resposta. Por favor revise.");

            var question = _questionRepository.Find(answer.QuestionId);
            if (question == null)
                throw new BizException(BizException.Error.NotFound, "Não encontramos a pergunta selecionada.");
            question.totalAnswers++;

            try
            {
                _unitOfWork.BeginTransaction();
                _answerRepository.Insert(answer);
                _questionRepository.Update(question);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }

        }

        public void AddLike(Like like)
        {
            if((like.QuestionId == null && like.AnswerId == null) || (like.QuestionId != null && like.AnswerId != null))
                throw new BizException("É obrigatório informar apenas um destino do Like.");

            var question = _questionRepository.Find(like.QuestionId);
            var answer = _answerRepository.Find(like.AnswerId);

            if (question == null && answer == null)
                throw new BizException(BizException.Error.NotFound, "Não encontramos o conteúdo selecionado.");

            if (question != null)
                AddLikeQuestion(like, question);
            else
                AddLikeAnswer(like, answer);

        }

        private void AddLikeQuestion(Like like, Question question)
        {
            var duplicatedLike = _likeRepository.Get().Where(l => l.User == like.User && l.QuestionId == like.QuestionId).Any();
            if (duplicatedLike)
                throw new BizException("Só pode curtir uma vez.");

            question.totalLikes++;

            try
            {
                _unitOfWork.BeginTransaction();
                _likeRepository.Insert(like);
                _questionRepository.Update(question);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }

        private void AddLikeAnswer(Like like, Answer answer)
        {
            var duplicatedLike = _likeRepository.Get().Where(l => l.User == like.User && l.AnswerId == like.AnswerId).Any();
            if (duplicatedLike)
                throw new BizException("Só pode curtir uma vez.");

            answer.totalLikes++;

            try
            {
                _unitOfWork.BeginTransaction();
                _likeRepository.Insert(like);
                _answerRepository.Update(answer);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}