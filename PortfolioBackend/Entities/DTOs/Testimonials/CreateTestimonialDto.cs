﻿namespace PortfolioBackend.Entities.DTOs.Testimonials
{
    public class CreateTestimonialDto
    {
        public string? TestimonialTitle { get; set; }
        public string? TestimonialContent { get; set; }
        public string? FullName { get; set; }
        public string? Job { get; set; }
    }
}