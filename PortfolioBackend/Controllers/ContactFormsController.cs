using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.Entities.DTOs.Contacts;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.ContactForms;
using PortfolioBackend.Entities.DTOs.Abouts;

namespace PortfolioBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactFormRepository _contactFormRepository;

        public ContactFormsController(IMapper mapper, IContactFormRepository contactFormRepository)
        {
            _mapper = mapper;
            _contactFormRepository = contactFormRepository;
        }

        [HttpGet("ContactForm/{Id}")]
        public async Task<IActionResult> ContactForm(int Id)
        {
            var result = await _contactFormRepository.GetAsync(c => c.ContactFormId == Id);
            GetContactFormDto getContactFormDto = _mapper.Map<GetContactFormDto>(result);
            if (result is null) return NotFound();
            return Ok(getContactFormDto);
        }
        [HttpGet("GetContactForms")]
        public async Task<IActionResult> GetContactForms()
        {
            var result = await _contactFormRepository.GetAllAsync();
            List<GetContactFormDto> getContactFormDtos = _mapper.Map<List<GetContactFormDto>>(result);
            if (result.Count == 0) return NotFound();
            return Ok(getContactFormDtos);

        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactFormDto contactFormDto)
        {
            ContactForm contactForm = _mapper.Map<ContactForm>(contactFormDto);
            await _contactFormRepository.AddAsync(contactForm);
            await _contactFormRepository.SaveAsync();
            return NoContent();
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (_contactFormRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var result = await _contactFormRepository.GetAsync(c => c.ContactFormId == Id);
            if (result is null) return BadRequest();
            _contactFormRepository.Delete(result);
            await _contactFormRepository.SaveAsync();
            return NoContent();

        }
    }
}
