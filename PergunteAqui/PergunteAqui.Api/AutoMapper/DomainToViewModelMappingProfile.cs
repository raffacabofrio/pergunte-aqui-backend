using AutoMapper;
using PergunteAqui.Api.ViewModels;
using PergunteAqui.Domain;
using PergunteAqui.Helper.Extensions;

namespace PergunteAqui.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : this("Profile")
        {
        }

        protected DomainToViewModelMappingProfile(string profileName) : base(profileName)
        {

            CreateMap<User, UserVM>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<Question, QuestionVM>();

        }
    }
}