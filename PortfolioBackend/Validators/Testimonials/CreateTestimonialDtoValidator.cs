using FluentValidation;
using PortfolioBackend.Entities.DTOs.Testimonials;

namespace PortfolioBackend.Validators.Testimonials
{
    public class CreateTestimonialDtoValidator:AbstractValidator<CreateTestimonialDto>
    {
        public CreateTestimonialDtoValidator()
        {
            this.ApplyCommonRules();
        }
    }
}
