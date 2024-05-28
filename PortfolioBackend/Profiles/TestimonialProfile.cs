using AutoMapper;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Testimonials;

namespace PortfolioBackend.Profiles
{
    public class TestimonialProfile:Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial, GetTestimonialDto>();
            CreateMap<UpdateTestimonialDto, Testimonial>();
            CreateMap<CreateTestimonialDto, Testimonial>();
        }
    }
}
