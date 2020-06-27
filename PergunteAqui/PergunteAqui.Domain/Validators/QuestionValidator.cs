using FluentValidation;
using System.Text.RegularExpressions;

namespace PergunteAqui.Domain.Validators
{
    public class QuestionValidator : AbstractValidator<Question>
    {


        public QuestionValidator()
        {
            RuleFor(q => q.Text)
               .NotEmpty()
               .WithMessage("Campo texto é obrigatório.");

            RuleFor(q => q.User)
                .NotEmpty()
                .WithMessage("Campo nome do usuário é obrigatório.");         
        }
    }
}
