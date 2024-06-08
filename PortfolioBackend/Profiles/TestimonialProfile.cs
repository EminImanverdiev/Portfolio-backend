using AutoMapper;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Testimonials;

namespace PortfolioBackend.Profiles
{
    public class TestimonialProfile:Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial, GetFactDto>();
            CreateMap<UpdateFactDto, Testimonial>();
            CreateMap<CreateFactDto, Testimonial>();
        }
    }
}
