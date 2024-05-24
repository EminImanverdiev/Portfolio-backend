using AutoMapper;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities.DTOs.Contacts;

namespace PortfolioBackend.Profiles
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, GetContactDto>();
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
        }
    }
}
