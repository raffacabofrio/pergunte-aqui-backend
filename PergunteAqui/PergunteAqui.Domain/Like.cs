using PergunteAqui.Domain.Common;
using System;

namespace PergunteAqui.Domain
{
    public class Like : BaseEntity
    {
        public string User { get; set; }

        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public Guid AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
