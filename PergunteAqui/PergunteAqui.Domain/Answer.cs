using PergunteAqui.Domain.Common;
using System;
using System.Collections.Generic;

namespace PergunteAqui.Domain
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; }
        public string User { get; set; }
        public virtual Question Question { get; set; }
        public virtual IList<Like> Likes { get; set; }
    }
}
