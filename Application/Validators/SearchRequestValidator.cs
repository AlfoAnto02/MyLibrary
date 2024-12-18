﻿using Application.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators {
    public class SearchRequestValidator : AbstractValidator<SearchRequest> {
        public SearchRequestValidator() {
            RuleFor(x => x.CategoryName)
            .NotEmpty()
                .When(x => string.IsNullOrWhiteSpace(x.BookName) &&
                       string.IsNullOrWhiteSpace(x.Author))
                .WithMessage("At least one parameter must be provided and non-empty.");

            RuleFor(x => x.BookName)
                .NotEmpty()
                .When(x => string.IsNullOrWhiteSpace(x.CategoryName) &&
                           string.IsNullOrWhiteSpace(x.Author))
                .WithMessage("At least one parameter must be provided and non-empty.");

            RuleFor(x => x.Author)
                .NotEmpty()
                .When(x => string.IsNullOrWhiteSpace(x.CategoryName) &&
                           string.IsNullOrWhiteSpace(x.BookName))
                .WithMessage("At least one parameter must be provided and non-empty.");

        }
    }
}
