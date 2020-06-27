using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PergunteAqui.Api.Filters;
using PergunteAqui.Api.ViewModels;
using PergunteAqui.Domain;
using PergunteAqui.Domain.Common;
using PergunteAqui.Domain.Enums;
using PergunteAqui.Domain.Exceptions;
using PergunteAqui.Infra.CrossCutting.Identity;
using PergunteAqui.Infra.CrossCutting.Identity.Interfaces;
using PergunteAqui.Service;

namespace PergunteAqui.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    [GetClaimsFilter]
    public class QAController : ControllerBase
    {
        private readonly IQAService _QAService;
        private readonly IApplicationSignInManager _signManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public QAController(IQAService QAService,
                                 IApplicationSignInManager signManager,
                                 IMapper mapper,
                                 IConfiguration configuration)
        {
            _QAService = QAService;
            _signManager = signManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("Questions")]
        public IList<QuestionVM> GetQuestions([FromQuery] string search = "")
        {
            var questions = _QAService.GetQuestions(search);
            var questionsVM = _mapper.Map<List<QuestionVM>>(questions);

            return questionsVM;
        }

        [HttpPost("AddQuestion")]
        public IActionResult AddQuestion([FromBody] QuestionAddVM questionAddVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _QAService.AddQuestion(questionAddVM.Text, questionAddVM.User);
            return Ok();
        }

        [HttpGet("Question/{questionId}/Answers")]
        public IList<AnswerVM> GetAnswers(Guid questionId)
        {
            var answers = _QAService.GetAnswers(questionId);
            var answersVM = _mapper.Map<List<AnswerVM>>(answers);

            return answersVM;
        }

        [HttpPost("AddAnswer")]
        public IActionResult AddAnswer([FromBody] AnswerAddVM answerAddVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var answer = _mapper.Map<Answer>(answerAddVM);

            _QAService.AddAnswer(answer);
            return Ok();
        }

        [HttpPost("AddLike")]
        public IActionResult AddLike([FromBody] Like like)
        {
            _QAService.AddLike(like);
            return Ok();
        }

    }
}