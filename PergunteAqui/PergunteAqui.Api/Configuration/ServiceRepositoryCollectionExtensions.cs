using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PergunteAqui.Domain;
using PergunteAqui.Domain.Validators;
using PergunteAqui.Infra.CrossCutting.Identity;
using PergunteAqui.Infra.CrossCutting.Identity.Interfaces;
using PergunteAqui.Repository;
using PergunteAqui.Repository.UoW;
using PergunteAqui.Service;

namespace PergunteAqui.Api.Configuration
{
    public static class ServiceRepositoryCollectionExtensions
    {
        public static IServiceCollection RegisterRepositoryServices(
           this IServiceCollection services)
        {
            //services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQAService, QAService>();

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();

            //validators
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<Question>, QuestionValidator>();

            //Auth
            services.AddScoped<IApplicationSignInManager, ApplicationSignInManager>();

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}