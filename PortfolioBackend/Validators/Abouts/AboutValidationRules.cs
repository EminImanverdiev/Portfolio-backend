using FluentValidation;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Validators.Abouts
{
    public static class AboutValidationRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : AboutDtoBase
        {
            validator.RuleFor(a => a.Title)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(300).WithMessage("Title must not exceed 300 characters!");

            validator.RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email must not be empty!")
                .NotNull().WithMessage("Email must not be null!")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters!");

            validator.RuleFor(a => a.Content)
                .NotEmpty().WithMessage("Content must not be empty!")
                .NotNull().WithMessage("Content must not be null!")
                .MaximumLength(300).WithMessage("Content must not exceed 300 characters!");

            validator.RuleFor(a => a.SubContent)
                .NotEmpty().WithMessage("SubContent must not be empty!")
                .NotNull().WithMessage("SubContent must not be null!")
                .MaximumLength(150).WithMessage("SubContent must not exceed 150 characters!");

            validator.RuleFor(a => a.City)
                .NotEmpty().WithMessage("City must not be empty!")
                .NotNull().WithMessage("City must not be null!")
                .MaximumLength(100).WithMessage("City must not exceed 100 characters!");

            validator.RuleFor(a => a.Birthday)
                .NotEmpty().WithMessage("Birthday must not be empty!")
                .NotNull().WithMessage("Birthday must not be null!")
                .MaximumLength(50).WithMessage("Birthday must not exceed 50 characters!");

            validator.RuleFor(a => a.Phone)
                .NotEmpty().WithMessage("Phone must not be empty!")
                .NotNull().WithMessage("Phone must not be null!")
                .MaximumLength(100).WithMessage("Phone must not exceed 100 characters!");

            validator.RuleFor(a => a.Degree)
                .NotEmpty().WithMessage("Degree must not be empty!")
                .NotNull().WithMessage("Degree must not be null!")
                .MaximumLength(30).WithMessage("Degree must not exceed 30 characters!");

            validator.RuleFor(a => a.Website)
                .NotEmpty().WithMessage("Website must not be empty!")
                .NotNull().WithMessage("Website must not be null!")
                .MaximumLength(200).WithMessage("Website must not exceed 200 characters!");

            validator.RuleFor(a => a.Freelance)
                .NotEmpty().WithMessage("Freelance must not be empty!")
                .NotNull().WithMessage("Freelance must not be null!")
                .MaximumLength(50).WithMessage("Freelance must not exceed 50 characters!");

            validator.RuleFor(a => a.Age)
                .NotEmpty().WithMessage("Age must not be empty!")
                .NotNull().WithMessage("Age must not be null!")
                .GreaterThan(0).WithMessage("Age must be greater than 0!");
        }
    }
}
