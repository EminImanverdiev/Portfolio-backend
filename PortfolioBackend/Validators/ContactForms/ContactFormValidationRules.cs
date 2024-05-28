using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities.DTOs.ContactForms;
using PortfolioBackend.Entities.DTOs.Contacts;

namespace PortfolioBackend.Validators.ContactForms
{
    public static class ContactFormValidationRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : ContactFormDtoBase
        {
            validator.RuleFor(c=>c.ContactFormName)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters!");
            validator.RuleFor(c => c.ContactFormEmail)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(50).WithMessage("Title must not exceed 50 characters!");
            validator.RuleFor(c => c.ContactFormSubject)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(50).WithMessage("Title must not exceed 50 characters!");
            validator.RuleFor(c => c.ContactFormMessage)
               .NotEmpty().WithMessage("Title must not be empty!")
               .NotNull().WithMessage("Title must not be null!")
               .MaximumLength(50).WithMessage("Title must not exceed 50 characters!");

        }

    }
}
