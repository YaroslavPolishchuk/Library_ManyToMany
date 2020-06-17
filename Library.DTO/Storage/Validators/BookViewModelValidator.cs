using FluentValidation;
using Library.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.Storage.Validators
{
    public class BookViewModelValidator:AbstractValidator<BookViewModel>
    {
        public BookViewModelValidator()
        {
            RuleFor(x => x.BookName).NotNull().WithMessage("Field couldn't be empty");
            RuleFor(x => x.PublishYear).GreaterThan(1600).WithMessage("Publish year should be grater than 1600");
        }
    }
}
