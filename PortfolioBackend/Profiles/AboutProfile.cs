using AutoMapper;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Profiles
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<About, GetAboutDto>();
            CreateMap<CreateAboutDto, About>();
            CreateMap<UpdateAboutDto, About>();
        }
    }
}
