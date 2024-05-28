using FluentValidation;
using PortfolioBackend.Entities.DTOs.Services;

namespace PortfolioBackend.Validators.Services
{
    public class CreateServiceDtoValidator:AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            this.ApplyCommonRules();
        }
    }
}
