using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

[Authorize]
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
        try
        {
            var result = await _aboutRepository.GetAllAsync();
            if (result == null || !result.Any()) return NotFound("No abouts found.");

            var getAboutDtos = _mapper.Map<List<GetAboutDto>>(result);
            return Ok(getAboutDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
        }
    }

    [HttpGet("GetAbout/{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        try
        {
            var result = await _aboutRepository.GetAsync(a => a.Id == id);
            if (result == null) return NotFound($"About with ID = {id} not found.");

            var getAboutDto = _mapper.Map<GetAboutDto>(result);
            return Ok(getAboutDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateAboutDto aboutDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var about = _mapper.Map<About>(aboutDto);

        // Dosya türü ve boyut kontrolü
        if (aboutDto.Photo != null && aboutDto.Photo.Length > 0)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(aboutDto.Photo.FileName).ToLower();
            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Invalid file type.");
            }

            if (aboutDto.Photo.Length > 10485760) // 10 MB
            {
                return BadRequest("File size exceeded the limit of 10MB.");
            }

            var photoPath = Path.Combine(_environment.WebRootPath, "photos", aboutDto.Photo.FileName);
            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                await aboutDto.Photo.CopyToAsync(stream);
            }
            about.Photo = "/photos/" + aboutDto.Photo.FileName;
        }

        try
        {
            await _aboutRepository.AddAsync(about);
            await _aboutRepository.SaveAsync();
            return CreatedAtAction(nameof(GetAbout), new { id = about.Id }, about);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new about record.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateAboutDto aboutDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await AboutExists(aboutDto.Id)) return NotFound($"About with ID = {aboutDto.Id} not found.");

        var about = _mapper.Map<About>(aboutDto);

        // Dosya türü ve boyut kontrolü
        if (aboutDto.Photo != null && aboutDto.Photo.Length > 0)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(aboutDto.Photo.FileName).ToLower();
            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Invalid file type.");
            }

            if (aboutDto.Photo.Length > 10485760) // 10 MB
            {
                return BadRequest("File size exceeded the limit of 10MB.");
            }

            var photoPath = Path.Combine(_environment.WebRootPath, "photos", aboutDto.Photo.FileName);
            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                await aboutDto.Photo.CopyToAsync(stream);
            }
            about.Photo = "/photos/" + aboutDto.Photo.FileName;
        }

        try
        {
            _aboutRepository.Update(about);
            await _aboutRepository.SaveAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating about record.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _aboutRepository.GetAsync(a => a.Id == id);
            if (result == null) return NotFound($"About with ID = {id} not found.");

            _aboutRepository.Delete(result);
            await _aboutRepository.SaveAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting about record.");
        }
    }

    private async Task<bool> AboutExists(int id)
    {
        return await _aboutRepository.IsExistsAsync(a => a.Id == id);
    }
}
