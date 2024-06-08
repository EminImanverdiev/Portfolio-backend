using FluentValidation;
using PortfolioBackend.Entities.DTOs.Skills;

namespace PortfolioBackend.Validators.Skills
{
    public static class SkillValidationRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : SkillDtoBase
        {
            validator.RuleFor(s => s.SkillName)
                .NotEmpty().WithMessage("Name must not be empty!")
                .NotNull().WithMessage("Name must not be null!")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters!");

        }

    }
}
