using Application.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;

namespace Application.Validators {
    public class AddBookRequestValidator : AbstractValidator<AddBookRequest> {
        public AddBookRequestValidator() {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLengthWithMessage(100, "Title can't be longer than 100 characters!!");
            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Author is required")
                .MaximumLengthWithMessage(100, "Author name can't be longer than 100 characters!!");
            RuleFor(x => x.Publisher)
                .NotEmpty()
                .WithMessage("Publisher is required")
                .MaximumLengthWithMessage(100, "Publisher Name can't be longer than 100 characters");
            RuleFor(x => x.Publication_Date)
                .Custom(DateChecker);
        }

        private void DateChecker(DateTime value, ValidationContext<AddBookRequest> context) {
            if (value == null) {
                context.AddFailure("Publication date is required");
            }
            if (value > DateTime.Now) {
                context.AddFailure("Publication date cannot be in the future");
            }
        }
    }
}
