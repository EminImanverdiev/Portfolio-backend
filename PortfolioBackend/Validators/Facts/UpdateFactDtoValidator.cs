using FluentValidation;
using PortfolioBackend.Entities.DTOs.Facts;

namespace PortfolioBackend.Validators.Facts
{
    public class UpdateFactDtoValidator : AbstractValidator<UpdateFactDto>
    {
        public UpdateFactDtoValidator()
        {
            this.ApplyCommonRules();

            RuleFor(f => f.FactId)
                .NotEmpty().WithMessage("ID must not be empty!")
                .NotNull().WithMessage("ID must not be null!")
                .GreaterThan(0).WithMessage("ID must be greater than 0!");
        }
    }

}
