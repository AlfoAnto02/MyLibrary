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
    public class AddCategoryRequestValidator : AbstractValidator<AddCategoryRequest> {
        public readonly CategoryRepository _categoriesRepository;

        public AddCategoryRequestValidator(CategoryRepository categoryRepository) {
            _categoriesRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Category Name Required")
                .Custom(BeUniqueName)
                .MinimumLength(3)
                .WithMessage("Category Name must be at least 3 characters long")
                .RegEx(@"^[a-zA-Z]*$", "Category name can only contains alphabetic character!");
        }

        private void BeUniqueName(string value, ValidationContext<AddCategoryRequest> context) {
            var category = _categoriesRepository.GetByName(value).Result;
            if (category != null) {
                context.AddFailure(new SameCategoryException(category.Name, category.Id).Message);
            }
        }
    }
}
