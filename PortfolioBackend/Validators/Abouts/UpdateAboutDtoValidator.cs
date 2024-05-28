using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Validators.Abouts
{
    public class UpdateAboutDtoValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutDtoValidator()
        {
            this.ApplyCommonRules();

            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("ID must not be empty!")
                .NotNull().WithMessage("ID must not be null!")
                .GreaterThan(0).WithMessage("ID must be greater than 0!");
        }
    }
}
