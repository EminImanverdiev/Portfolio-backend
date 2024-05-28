using FluentValidation;
using PortfolioBackend.Entities.DTOs.Services;

namespace PortfolioBackend.Validators.Services
{
    public class UpdateServiceDtoValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceDtoValidator()
        {
            this.ApplyCommonRules();
            RuleFor(s => s.ServiceId)
             .NotEmpty().WithMessage("ID must not be empty!")
             .NotNull().WithMessage("ID must not be null!")
             .GreaterThan(0).WithMessage("ID must be greater than 0!");

        }
    }
}
