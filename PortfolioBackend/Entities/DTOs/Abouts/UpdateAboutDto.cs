namespace PortfolioBackend.Entities.DTOs.Abouts
{
    public class UpdateAboutDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? SubContent { get; set; }
        public string? Birthday { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Degree { get; set; }
        public string? Freelance { get; set; }
        public int Age { get; set; }
    }
}
