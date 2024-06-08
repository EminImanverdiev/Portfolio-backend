using FluentValidation;
using PortfolioBackend.Entities.DTOs.Skills;

namespace PortfolioBackend.Validators.Skills
{
    public class UpdateSkillDtoValidator : AbstractValidator<UpdateSkillDto>
    {
        public UpdateSkillDtoValidator()
        {
            this.ApplyCommonRules();
            RuleFor(s=>s.SkillId)
              .NotEmpty().WithMessage("ID must not be empty!")
              .NotNull().WithMessage("ID must not be null!")
              .GreaterThan(0).WithMessage("ID must be greater than 0!");

        }
    }

}
