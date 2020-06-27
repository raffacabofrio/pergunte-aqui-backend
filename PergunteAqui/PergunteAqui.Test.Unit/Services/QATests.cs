using Moq;
using PergunteAqui.Domain;
using PergunteAqui.Domain.Common;
using PergunteAqui.Domain.Validators;
using PergunteAqui.Repository;
using PergunteAqui.Repository.Repository;
using PergunteAqui.Service;
using PergunteAqui.Test.Unit.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Xunit;
using PergunteAqui.Repository.UoW;
using PergunteAqui.Infra.CrossCutting.Identity.Interfaces;
using PergunteAqui.Domain.Exceptions;

namespace PergunteAqui.Test.Unit.Services
{
    public class QAServiceTests
    {

        readonly Mock<IQuestionRepository> questionRepositoryMock;
        readonly Mock<IAnswerRepository> answerRepositoryMock;
        readonly Mock<ILikeRepository> likeRepositoryMock;
        readonly Mock<IUnitOfWork> unitOfWorkMock;

        readonly QAService service;

        Guid questionId1 = new Guid("de80573c-38a8-4509-ba53-ee8a5a64df11");
        Guid questionId2 = new Guid("801700d0-16b8-4c59-9b42-ebdce85a75c7");

        Guid answerId1 = new Guid("c51bfc50-1627-4803-9a32-6166a852eff6");
        Guid answerId2 = new Guid("252bd59d-f859-4f3e-aefd-d4a5b48f9385");

        public QAServiceTests()
        {
            // Definindo quais serão as classes mockadas
            questionRepositoryMock = new Mock<IQuestionRepository>();
            answerRepositoryMock = new Mock<IAnswerRepository>();
            likeRepositoryMock = new Mock<ILikeRepository>();
            unitOfWorkMock = new Mock<IUnitOfWork>();



            service = new QAService(questionRepositoryMock.Object, unitOfWorkMock.Object, new QuestionValidator(), answerRepositoryMock.Object, likeRepositoryMock.Object);

            questionRepositoryMock.Setup(repo => repo.Find(questionId1)).Returns(() =>
            {
                return new Question()
                {
                    Id = questionId1
                };
            });

            answerRepositoryMock.Setup(repo => repo.Find(answerId1)).Returns(() =>
            {
                return new Answer()
                {
                    Id = answerId1
                };
            });
        }

        [Fact]
        public void ShouldNotAddQuestionWithBadWord()
        {
            //arrange

            //act
            Action act = () => service.AddQuestion("Pergunta inadequada, caralho.", "Usuário 01");

            //assert
            var exception = Assert.Throws<BizException>(act);
            Assert.Equal("Tem algum conteúdo indevido na sua pergunta. Por favor revise.", exception.Message);
        }

        [Fact]
        public void ShouldAddValidQuestion()
        {
            //arrange

            //act
            try
            {
                service.AddQuestion("Pergunta adequada.", "Usuário 01");
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ShouldNotAddAnswerWithBadWord()
        {
            //arrange

            //act
            var answer = new Answer()
            {
                Text = "Resposta inadequada, porra!"
            };
            Action act = () => service.AddAnswer(answer);

            //assert
            var exception = Assert.Throws<BizException>(act);
            Assert.Equal("Tem algum conteúdo indevido na sua resposta. Por favor revise.", exception.Message);
        }

        [Fact]
        public void ShouldNotAddAnswerWhenQuestionNotFound()
        {
            //arrange

            //act
            var answer = new Answer()
            {
                Text = "Resposta adequada.",
                QuestionId = questionId2
            };
            Action act = () => service.AddAnswer(answer);

            //assert
            var exception = Assert.Throws<BizException>(act);
            Assert.Equal("Não encontramos a pergunta selecionada.", exception.Message);
        }

        [Fact]
        public void ShouldAddValidAnswer()
        {
            //arrange

            //act
            try
            {
                var answer = new Answer()
                {
                    Text = "Resposta adequada.",
                    QuestionId = questionId1
                };
                service.AddAnswer(answer);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ShouldNotAddLikeBothContentsSameTime()
        {
            //arrange

            //act
            var like = new Like()
            {
                User = "Usuário 01",
                QuestionId = questionId1,
                AnswerId = answerId1
            };
            Action act = () => service.AddLike(like);

            //assert
            var exception = Assert.Throws<BizException>(act);
            Assert.Equal("É obrigatório informar apenas um destino do Like.", exception.Message);
        }

        [Fact]
        public void ShouldNotAddLikeWhenQuestionNotFound()
        {
            //arrange

            //act
            var like = new Like()
            {
                User = "Usuário 01",
                QuestionId = questionId2,
            };
            Action act = () => service.AddLike(like);

            //assert
            var exception = Assert.Throws<BizException>(act);
            Assert.Equal("Não encontramos o conteúdo selecionado.", exception.Message);
        }

        [Fact]
        public void ShouldNotAddLikeWhenAnswerNotFound()
        {
            //arrange

            //act
            var like = new Like()
            {
                User = "Usuário 01",
                AnswerId = answerId2,
            };
            Action act = () => service.AddLike(like);

            //assert
            var exception = Assert.Throws<BizException>(act);
            Assert.Equal("Não encontramos o conteúdo selecionado.", exception.Message);
        }

        [Fact]
        public void ShouldAddValidLike()
        {
            //arrange

            //act
            try
            {
                //act
                var like = new Like()
                {
                    User = "Usuário 01",
                    AnswerId = answerId1,
                };
                service.AddLike(like);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

    }
}
