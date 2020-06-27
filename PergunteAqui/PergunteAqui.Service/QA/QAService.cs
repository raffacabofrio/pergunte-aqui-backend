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


        public QAService(IQuestionRepository questionRepository,
            IUnitOfWork unitOfWork,
            IValidator<Question> validator) : base(questionRepository, unitOfWork, validator)
        {
            _questionRepository = questionRepository;
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
    }
}