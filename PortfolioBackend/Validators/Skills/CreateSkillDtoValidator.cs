using FluentValidation;
using PortfolioBackend.Entities.DTOs.Skills;

namespace PortfolioBackend.Validators.Skills
{
    public class CreateSkillDtoValidator:AbstractValidator<CreateSkillDto>
    {
        public CreateSkillDtoValidator()
        {
            this.ApplyCommonRules();

        }
    }

}
