using AutoMapper;
using PortfolioBackend.Entities.Auth;
using PortfolioBackend.Entities.DTOs.Auth;

namespace PortfolioBackend.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<LoginDto, AppUser>();
        }
    }
}
