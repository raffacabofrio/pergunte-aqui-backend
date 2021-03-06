﻿using PergunteAqui.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace PergunteAqui.Api.ViewModels
{
    public class QuestionVM
    {
        public string Text { get; set; }
        public string User { get; set; }
        public int totalLikes { get; set; }
        public int totalAnswers { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid Id { get; set; }
    }

    public class QuestionAddVM
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string User { get; set; }
    }
}
