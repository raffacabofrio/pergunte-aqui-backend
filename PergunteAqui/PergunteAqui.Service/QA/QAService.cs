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
    }
}