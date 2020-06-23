﻿using FluentValidation;
using ShareBook.Domain.Enums;

namespace ShareBook.Domain.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        #region Messages
        public const string Title = "Titulo do livro é obrigatório";
        public const string Author = "Autor do livro é obrigatório";
        public const string Image = "Imagem do livro é obrigatória";
        public const string Categoria = "Categoria do livro é obrigatória";
        public const string User = "O usuário deve ter vinculo com o livro";
        public const string FreightOption = "A opção de frete é obrigatória";
        public const string HasNotImageExtension = "A extensão da imagem não é válida. É preciso ser png, jpg ou jpeg.";
        #endregion

        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage(Title);

            RuleFor(b => b.Author)
               .NotEmpty()
               .WithMessage(Author);

            RuleFor(b => b.ImageName)
               .NotEmpty()
               .WithMessage(Image)
               .Must(HasImageExtension)
               .WithMessage(HasNotImageExtension);

            RuleFor(b => b.ImageBytes)
                .NotEmpty()
                .WithMessage(Image);

            RuleFor(b => b.FreightOption)
                .Must(FreightOptionIsValid)
                .WithMessage(FreightOption);

            RuleFor(b => b.UserId)
                .NotEmpty()
                .WithMessage(User);

            RuleFor(b => b.CategoryId)
               .NotEmpty()
               .WithMessage(Categoria);
        }


        private bool HasImageExtension(string image)
        {
            return (!string.IsNullOrEmpty(image) && 
                       (image.ToLower().EndsWith(".png") 
                       || image.ToLower().EndsWith(".jpg")
                       || image.ToLower().EndsWith(".jpeg"))
                   );
        }

        private bool FreightOptionIsValid(FreightOption freightOption)
        {
            return !string.IsNullOrEmpty(freightOption.ToString());
        }
    }
}
