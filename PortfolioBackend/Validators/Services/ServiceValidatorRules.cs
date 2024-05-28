using FluentValidation;
using PortfolioBackend.Entities.DTOs.Contacts;
using PortfolioBackend.Entities.DTOs.Services;

namespace PortfolioBackend.Validators.Services
{
    public static class ServiceValidatorRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : ServiceDtoBase
        {
            validator.RuleFor(s=>s.ServiceTitle)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(400).WithMessage("Title must not exceed 400 characters!");
            validator.RuleFor(s => s.ServiceName)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters!");
            validator.RuleFor(s => s.ServiceContent)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(200).WithMessage("Title must not exceed 200 characters!");


        }
    }
}
