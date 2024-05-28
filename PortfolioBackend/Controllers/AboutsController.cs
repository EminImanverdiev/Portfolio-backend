using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Repositories.EFcore;

namespace PortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public AboutsController(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAbouts")]
        public async Task<IActionResult> GetAbouts()
        {
            var result = await _aboutRepository.GetAllAsync();
            List<GetAboutDto> getaboutdtos=_mapper.Map<List<GetAboutDto>>(result);
            if(result.Count==0)return NotFound();
            return Ok(getaboutdtos);

        }
        [HttpGet("GetAbout/{Id}")]
        public async Task<IActionResult> GetAbout(int Id)
        {
            var result = await _aboutRepository.GetAsync(a => a.Id == Id);
            GetAboutDto getAboutDto=_mapper.Map<GetAboutDto>(result);   
            if (result is null) return NotFound();
            return Ok(getAboutDto);
            
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAboutDto aboutDto)
        {
            About about =_mapper.Map<About>(aboutDto);
            await _aboutRepository.AddAsync(about);
            await _aboutRepository.SaveAsync(); 
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
        {
            if (!await AboutExists(aboutDto.Id)) return NotFound();
           
            About about = _mapper.Map<About>(aboutDto);
              _aboutRepository.Update(about);
            await _aboutRepository.SaveAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (_aboutRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var result = await _aboutRepository.GetAsync(a => a.Id == Id);
            if (result is null) return BadRequest();
             _aboutRepository.Delete(result);
            await _aboutRepository.SaveAsync();
            return NoContent();

        }
        private Task<bool> AboutExists(int Id)
    {
        return _aboutRepository.IsExistsAsync(a => a.Id == Id);
    }

}
}
