using FluentValidation;
using PortfolioBackend.Entities.DTOs.Facts;

namespace PortfolioBackend.Validators.Facts
{
    public static class FactValidationRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : FactDtoBase
        {
            validator.RuleFor(f => f.FactName)
                .NotEmpty().WithMessage("Name must not be empty!")
                .NotNull().WithMessage("Name must not be null!")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters!");
        }

    }
}
