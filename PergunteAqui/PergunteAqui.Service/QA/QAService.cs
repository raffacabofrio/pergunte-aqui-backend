using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FluentValidation;
using PergunteAqui.Domain;
using PergunteAqui.Domain.Common;
using PergunteAqui.Domain.Exceptions;
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

        public IList<Question> GetQuestions()
        {
            return _questionRepository.Get().ToList();
        }
    }
}