using PergunteAqui.Domain;
using PergunteAqui.Domain.Common;
using PergunteAqui.Domain.Enums;
using PergunteAqui.Service.Generic;
using System;
using System.Collections.Generic;

namespace PergunteAqui.Service
{
    public interface IQAService : IBaseService<Question>
    {
        IList<Question> GetQuestions(string search);
        void AddQuestion(string text, string user);
        IList<Answer> GetAnswers(Guid questionId);
    }
}
