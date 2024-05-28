using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities.DTOs.ContactForms;
using PortfolioBackend.Entities.DTOs.Contacts;

namespace PortfolioBackend.Validators.ContactForms
{
    public static class ContactValidationRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : ContactDtoBase
        {
            validator.RuleFor(c => c.ContactTitle)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(300).WithMessage("Title must not exceed 300 characters!");
            validator.RuleFor(c => c.ContactEmail)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(100).WithMessage("Title must not exceed 100 characters!");
            validator.RuleFor(c => c.ContactNumber)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(100).WithMessage("Title must not exceed 100 characters!");
            validator.RuleFor(c => c.ContactLocation)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(300).WithMessage("Title must not exceed 300 characters!");

        }

    }
}
