using Newtonsoft.Json;
using PergunteAqui.Domain;
using System.ComponentModel.DataAnnotations;

namespace PergunteAqui.Api.ViewModels
{
    public class UpdateUserVM : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Linkedin { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public bool AllowSendingEmail { get; set; }
    }
}
