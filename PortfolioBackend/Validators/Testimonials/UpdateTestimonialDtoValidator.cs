using FluentValidation;
using PortfolioBackend.Entities.DTOs.Testimonials;

namespace PortfolioBackend.Validators.Testimonials
{
    public class UpdateTestimonialDtoValidator : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialDtoValidator()
        {
            this.ApplyCommonRules();
            RuleFor(t=> t.TestimonialId)
          .NotEmpty().WithMessage("ID must not be empty!")
          .NotNull().WithMessage("ID must not be null!")
          .GreaterThan(0).WithMessage("ID must be greater than 0!");

        }
    }
}
