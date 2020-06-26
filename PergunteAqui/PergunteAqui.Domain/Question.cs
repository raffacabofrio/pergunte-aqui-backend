using PergunteAqui.Domain.Common;
using System;

namespace PergunteAqui.Domain
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public string User { get; set; }
    }
}
