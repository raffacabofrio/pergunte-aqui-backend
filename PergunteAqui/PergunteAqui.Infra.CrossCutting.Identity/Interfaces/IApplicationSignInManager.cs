using PergunteAqui.Domain;
using PergunteAqui.Infra.CrossCutting.Identity;

namespace PergunteAqui.Infra.CrossCutting.Identity.Interfaces
{
    public interface IApplicationSignInManager
    {
        object GenerateTokenAndSetIdentity(User user, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations);
    }
}
