using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Validators.Abouts
{
    public class CreateAboutValidator:AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!");
        }
    }
}
