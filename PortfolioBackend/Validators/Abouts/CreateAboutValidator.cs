using FluentValidation;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Validators.Abouts
{
    public class CreateAboutValidator:AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
        //    RuleFor(a => a.Title)
        //        .NotEmpty().WithMessage("Title must not be empty!")
        //        .MaximumLength(100).WithMessage("Title must not exceed 100 characters!");
        //
        }
    }
    }
