using FluentValidation;
using PortfolioBackend.Entities.DTOs.ContactForms;

namespace PortfolioBackend.Validators.ContactForms
{
    public class UpdateContactFormDtoValidator : AbstractValidator<UpdateContactFormDto>
    {
        public UpdateContactFormDtoValidator()
        {
            this.ApplyCommonRules();
            RuleFor(c => c.ContactFormId)
              .NotEmpty().WithMessage("ID must not be empty!")
              .NotNull().WithMessage("ID must not be null!")
              .GreaterThan(0).WithMessage("ID must be greater than 0!");
        }
    }

}
