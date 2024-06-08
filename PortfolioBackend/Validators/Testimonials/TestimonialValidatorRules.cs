using FluentValidation;
using PortfolioBackend.Entities.DTOs.Services;
using PortfolioBackend.Entities.DTOs.Testimonials;

namespace PortfolioBackend.Validators.Testimonials
{
    public static class TestimonialValidatorRules
    {
        public static void ApplyCommonRules<T>(this AbstractValidator<T> validator) where T : FactDtoBase
        {
            validator.RuleFor(t=>t.TestimonialTitle)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(300).WithMessage("Title must not exceed 300 characters!");
            validator.RuleFor(t => t.TestimonialContent)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(400).WithMessage("Title must not exceed 400 characters!");
            validator.RuleFor(t => t.FullName)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(40).WithMessage("Title must not exceed 40 characters!");
            validator.RuleFor(t => t.Job)
                .NotEmpty().WithMessage("Title must not be empty!")
                .NotNull().WithMessage("Title must not be null!")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters!");

        }
    }
}
