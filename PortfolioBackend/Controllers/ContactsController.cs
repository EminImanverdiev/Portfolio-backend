using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities.DTOs.Contacts;
using PortfolioBackend.Entities;

[Authorize]
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
    public async Task<IActionResult> GetContact(int Id)
    {
        var result = await _contactRepository.GetAsync(c => c.ContactId == Id);
        if (result is null) return NotFound();
        var getContactDto = _mapper.Map<GetContactDto>(result);
        return Ok(getContactDto);
    }

    [HttpGet("GetContacts")]
    public async Task<IActionResult> GetContacts()
    {
        var result = await _contactRepository.GetAllAsync();
        if (!result.Any()) return NotFound();
        var getContactDtos = _mapper.Map<List<GetContactDto>>(result);
        return Ok(getContactDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateContactDto contactDto)
    {
        var contact = _mapper.Map<Contact>(contactDto);
        await _contactRepository.AddAsync(contact);
        await _contactRepository.SaveAsync();
        return CreatedAtAction(nameof(GetContact), new { Id = contact.ContactId }, contact);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateContactDto contactDto)
    {
        if (!await ContactExists(contactDto.ContactId)) return NotFound();
        var contact = _mapper.Map<Contact>(contactDto);
        _contactRepository.Update(contact);
        await _contactRepository.SaveAsync();
        return NoContent();
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        var result = await _contactRepository.GetAsync(c => c.ContactId == Id);
        if (result is null) return NotFound();
        _contactRepository.Delete(result);
        await _contactRepository.SaveAsync();
        return NoContent();
    }

    private Task<bool> ContactExists(int Id)
    {
        return _contactRepository.IsExistsAsync(c => c.ContactId == Id);
    }
}
