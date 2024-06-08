namespace PortfolioBackend.Entities.DTOs.Testimonials
{
    public class FactDtoBase
    {
        public int TestimonialId { get; set; }
        public string? TestimonialTitle { get; set; }
        public string? TestimonialContent { get; set; }
        public string? FullName { get; set; }
        public string? Job { get; set; }
    }
}
