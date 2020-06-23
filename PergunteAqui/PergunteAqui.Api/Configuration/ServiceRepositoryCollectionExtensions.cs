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


            //repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //validators
            services.AddScoped<IValidator<User>, UserValidator>();

            //Auth
            services.AddScoped<IApplicationSignInManager, ApplicationSignInManager>();

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}