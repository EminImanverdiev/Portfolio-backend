using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities.DTOs.Facts;

namespace PortfolioBackend.Validators.Facts
{
    public class CreateFactDtoValidator:AbstractValidator<CreateFactDto>
    {
        public CreateFactDtoValidator()
        {
            this.ApplyCommonRules();

        }
    }

}
