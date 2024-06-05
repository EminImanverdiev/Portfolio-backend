using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AboutsController : ControllerBase
{
    private readonly IAboutRepository _aboutRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;

    public AboutsController(IAboutRepository aboutRepository, IMapper mapper, IWebHostEnvironment environment)
    {
        _aboutRepository = aboutRepository;
        _mapper = mapper;
        _environment = environment;
    }

    [HttpGet("GetAbouts")]
    public async Task<IActionResult> GetAbouts()
    {
        var result = await _aboutRepository.GetAllAsync();
        if (result == null || !result.Any()) return NotFound();

        var getAboutDtos = _mapper.Map<List<GetAboutDto>>(result);
        return Ok(getAboutDtos);
    }

    [HttpGet("GetAbout/{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var result = await _aboutRepository.GetAsync(a => a.Id == id);
        if (result == null) return NotFound();

        var getAboutDto = _mapper.Map<GetAboutDto>(result);
        return Ok(getAboutDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateAboutDto aboutDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var about = _mapper.Map<About>(aboutDto);

        // Photo dosyasını kaydetme işlemi
        if (aboutDto.Photo != null && aboutDto.Photo.Length > 0)
        {
            var photoPath = Path.Combine(_environment.WebRootPath, "photos", aboutDto.Photo.FileName);
            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                await aboutDto.Photo.CopyToAsync(stream);
            }
            about.Photo = "/photos/" + aboutDto.Photo.FileName; // photo alanına dosya yolunu ekliyoruz
        }

        await _aboutRepository.AddAsync(about);
        await _aboutRepository.SaveAsync();

        return CreatedAtAction(nameof(GetAbout), new { id = about.Id }, about);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateAboutDto aboutDto)
    {
        if (!await AboutExists(aboutDto.Id)) return NotFound();

        var about = _mapper.Map<About>(aboutDto);

        // Photo dosyasını güncelleme işlemi
        if (aboutDto.Photo != null && aboutDto.Photo.Length > 0)
        {
            var photoPath = Path.Combine(_environment.WebRootPath, "photos", aboutDto.Photo.FileName);
            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                await aboutDto.Photo.CopyToAsync(stream);
            }
            about.Photo = "/photos/" + aboutDto.Photo.FileName; // photo alanına dosya yolunu ekliyoruz
        }

        _aboutRepository.Update(about);
        await _aboutRepository.SaveAsync();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _aboutRepository.GetAsync(a => a.Id == id);
        if (result == null) return NotFound();

        _aboutRepository.Delete(result);
        await _aboutRepository.SaveAsync();
        return NoContent();
    }

    private Task<bool> AboutExists(int id)
    {
        return _aboutRepository.IsExistsAsync(a => a.Id == id);
    }
}
