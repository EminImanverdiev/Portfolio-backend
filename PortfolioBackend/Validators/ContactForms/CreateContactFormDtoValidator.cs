using FluentValidation;
using PortfolioBackend.Entities.DTOs.ContactForms;
using PortfolioBackend.Entities.DTOs.Contacts;

namespace PortfolioBackend.Validators.ContactForms
{
    public class CreateContactDtoValidator:AbstractValidator<UpdateContactDto>
    {
        public CreateContactDtoValidator()
        {
            this.ApplyCommonRules();
        }
    }

}
