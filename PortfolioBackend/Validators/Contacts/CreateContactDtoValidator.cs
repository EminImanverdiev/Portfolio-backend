using FluentValidation;
using PortfolioBackend.Entities.DTOs.Contacts;
using PortfolioBackend.Validators.ContactForms;

namespace PortfolioBackend.Validators.Contacts
{
    public class CreateContactDtoValidator:AbstractValidator<UpdateContactDto>
    {
        public CreateContactDtoValidator()
        {
            this.ApplyCommonRules();
        }
    }
}
