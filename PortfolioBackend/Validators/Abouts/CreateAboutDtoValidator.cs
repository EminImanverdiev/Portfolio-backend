using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Validators.Abouts
{
    public class CreateAboutDtoValidator:AbstractValidator<CreateAboutDto>
    {
        public CreateAboutDtoValidator()
        {
           this.ApplyCommonRules();
        }
    }
}
