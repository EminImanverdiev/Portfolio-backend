namespace PortfolioBackend.Entities.DTOs.Abouts
{
    public class CreateAboutDto:AboutDtoBase
    {
        public IFormFile Photo { get; set; }

    }
}
