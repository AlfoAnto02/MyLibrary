using Application.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators {
    public class PaginationRequestValidator : AbstractValidator<PaginationRequest> {
        public PaginationRequestValidator() {
            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page Size must be greater than 0");
            RuleFor(x => x.PageNumber)
                .NotNull()
                .WithMessage("Page Number can't be null");
        }
    }
}
