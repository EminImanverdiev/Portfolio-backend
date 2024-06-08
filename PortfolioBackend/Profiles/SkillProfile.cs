using AutoMapper;
using PortfolioBackend.Entities.DTOs.Services;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Skills;

namespace PortfolioBackend.Profiles
{
    public class SkillProfile:Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, GetSkillDto>();
            CreateMap<CreateSkillDto, Skill>();
            CreateMap<UpdateSkillDto, Skill>();
        }
    }
}
