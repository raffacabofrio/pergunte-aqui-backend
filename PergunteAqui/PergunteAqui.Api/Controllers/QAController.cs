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

        [HttpGet("questions")]
        public Result GetQuestions()
        {
            var questions = _QAService.GetQuestions();

            return new Result()
            {
                Value = questions
            };
        }


    }
}