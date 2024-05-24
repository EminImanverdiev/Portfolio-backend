using AutoMapper;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Services;

namespace PortfolioBackend.Profiles
{
    public class ServiceProfile:Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, GetServiceDto>();
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();
        }
    }
}
