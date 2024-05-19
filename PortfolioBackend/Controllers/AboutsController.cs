using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Repositories.EFcore;

namespace PortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AboutsController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAbouts")]

        public async Task<IActionResult> GetAbouts()
        {
            var result = await _context.Abouts.ToListAsync();
            List<GetAboutDto> getaboutdtos=_mapper.Map<List<GetAboutDto>>(result);
            if(result.Count==0)return NotFound();
            return Ok(getaboutdtos);

        }
        [HttpGet("GetAbout/{Id}")]
        public async Task<IActionResult> GetAbout(int Id)
        {
            var result = await _context.Abouts.Where(a=>a.Id==Id).FirstOrDefaultAsync();
            GetAboutDto getAboutDto=_mapper.Map<GetAboutDto>(result);   
            if (result is null) return NotFound();
            return Ok(getAboutDto);
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto aboutDto)
        {
            About about =_mapper.Map<About>(aboutDto);
            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();  
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
        {
            if (!AboutExists(aboutDto.Id)) return NotFound();
           
            About about = _mapper.Map<About>(aboutDto);
             _context.Abouts.Update(about);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result=await _context.Abouts.FindAsync(Id);
            if (result is null) return BadRequest();
            _context.Abouts.Remove(result);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        private bool AboutExists(int Id)
        {
            return _context.Abouts.Any(a => a.Id == Id);
        }

    }
}
