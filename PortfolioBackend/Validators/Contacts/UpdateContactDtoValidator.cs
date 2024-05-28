using FluentValidation;
using PortfolioBackend.Entities.DTOs.Contacts;
using PortfolioBackend.Validators.ContactForms;

namespace PortfolioBackend.Validators.Contacts
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            this.ApplyCommonRules();
            RuleFor(c => c.ContactId)
             .NotEmpty().WithMessage("ID must not be empty!")
             .NotNull().WithMessage("ID must not be null!")
             .GreaterThan(0).WithMessage("ID must be greater than 0!");
        }
    }
}
