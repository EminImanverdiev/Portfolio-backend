using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities.DTOs.ContactForms;
using PortfolioBackend.Entities.DTOs.Contacts;
using System.Net;

namespace PortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        [HttpGet("GetContact/{Id}")]
        public async Task<IActionResult> GetContact(int Id) {
            var result = await _contactRepository.GetAsync(c => c.ContactId == Id);
            GetContactDto getContactDto = _mapper.Map<GetContactDto>(result);
            if (result is null) return NotFound();
            return Ok(getContactDto);
        }
        [HttpGet("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _contactRepository.GetAllAsync();
            List<GetContactDto> getContactDtos = _mapper.Map<List<GetContactDto>>(result);
            if (result.Count == 0) return NotFound();
            return Ok(getContactDtos);

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.AddAsync(contact);
            await _contactRepository.SaveAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto contactDto)
        {
            if (!await ContactExists(contactDto.ContactId)) return NotFound();

            Contact contact = _mapper.Map<Contact>(contactDto);
            _contactRepository.Update(contact);
            await _contactRepository.SaveAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (_contactRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var result = await _contactRepository.GetAsync(c => c.ContactId == Id);
            if (result is null) return BadRequest();
            _contactRepository.Delete(result);
            await _contactRepository.SaveAsync();
            return NoContent();

        }
        private Task<bool> ContactExists(int Id)
        {
            return _contactRepository.IsExistsAsync(c => c.ContactId == Id);
        }


    }
}
