using PergunteAqui.Domain;
using PergunteAqui.Domain.Common;
using PergunteAqui.Service.Generic;
using System;
using System.Collections.Generic;

namespace PergunteAqui.Service
{
    public interface IQAService : IBaseService<Question>
    {
        IList<Question> GetQuestions();
    }
}
