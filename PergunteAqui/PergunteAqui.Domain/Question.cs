﻿using PergunteAqui.Domain.Common;
using System;
using System.Collections.Generic;

namespace PergunteAqui.Domain
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public string User { get; set; }
        public virtual IList<Answer> Answers { get; set; }
        public virtual IList<Like> Likes { get; set; }

        // for performance improvement on queries and searches.
        public int totalLikes { get; set; } = 0;
        public int totalAnswers { get; set; } = 0;
    }
}
