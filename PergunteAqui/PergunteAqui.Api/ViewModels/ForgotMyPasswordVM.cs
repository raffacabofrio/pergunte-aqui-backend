using System.ComponentModel.DataAnnotations;

namespace PergunteAqui.Api.ViewModels
{
    public class ForgotMyPasswordVM
    {
        [Required]
        public string Email { get; set; }
    }
}
