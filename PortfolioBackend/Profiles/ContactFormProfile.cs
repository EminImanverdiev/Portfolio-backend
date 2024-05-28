using AutoMapper;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.ContactForms;

namespace PortfolioBackend.Profiles
{
    public class ContactFormProfile:Profile
    {
        public ContactFormProfile()
        {
            CreateMap<ContactForm, GetContactFormDto>();
            CreateMap<CreateContactFormDto, ContactForm>();
        }
    }
}
