using Application.Exceptions;
using Application.Extensions;
using Application.Models.Request;
using FluentValidation;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators {
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest> {
        public readonly UserRepository _userRepository;
        public AddUserRequestValidator(UserRepository userRepository) {
            this._userRepository = userRepository;

            RuleFor(x => x.Name)
                .Custom(CustomNameRule);

            RuleFor(x => x.Surname)
                .Custom(CustomNameRule);

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email can't be Null!!")
                .Custom(AlreadyRegisteredRule)
                .MinimumLength(4)
                .WithMessage("Email address needs to be at least 4 character longer")
                .MaximumLength(320)
                .WithMessage("Email address can't be longer than 320 characters")
                .RegEx(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", "Email address inserted has an incorrect format: Username@domain.domainName");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password can't be null")
                .RegEx(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:,<.>]).{8,}$",
                       "Password needs to be at least 8 character longer with at least 1 upper case, 1 number and 1 special character!!");
        }


        private void CustomNameRule(string value, ValidationContext<AddUserRequest> context) {
            if (value == null) {
                context.AddFailure("Name and surname required");
            }
            if (value.Length < 3 || value.Length > 100) {
                context.AddFailure("Name must be between 3 and 100 characters");
            }
        }

        private void AlreadyRegisteredRule(string value, ValidationContext<AddUserRequest> context) {
            if (_userRepository.GetByEmail(value).Result != null) {
                context.AddFailure(new SameUserException(value).Message);
            }
        }
    }
}
