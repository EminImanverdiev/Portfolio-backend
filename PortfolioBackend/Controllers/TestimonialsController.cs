using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Testimonials;

namespace PortfolioBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }

        [HttpGet("GetTestimonials")]
        public async Task<IActionResult> GetTestimonials()
        {
            var result = await _testimonialRepository.GetAllAsync();
            List<GetFactDto> getTestimonialDtos = _mapper.Map<List<GetFactDto>>(result);
            if (result.Count == 0) return NotFound();
            return Ok(getTestimonialDtos);

        }
        [HttpGet("GetTestimonial/{Id}")]
        public async Task<IActionResult> GetTestimonial(int Id)
        {
            var result = await _testimonialRepository.GetAsync(a => a.TestimonialId == Id);
            GetFactDto getTestimonialDto = _mapper.Map<GetFactDto>(result);
            if (result is null) return NotFound();
            return Ok(getTestimonialDto);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFactDto testimonialDto)
        {
            Testimonial testimonial = _mapper.Map<Testimonial>(testimonialDto);
            await _testimonialRepository.AddAsync(testimonial);
            await _testimonialRepository.SaveAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFactDto testimonialDto)
        {
            if (!await AboutExists(testimonialDto.TestimonialId)) return NotFound();

            Testimonial testimonial = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialRepository.Update(testimonial);
            await _testimonialRepository.SaveAsync();
            return NoContent();
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (_testimonialRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var result = await _testimonialRepository.GetAsync(a => a.TestimonialId == Id);
            if (result is null) return BadRequest();
            _testimonialRepository.Delete(result);
            await _testimonialRepository.SaveAsync();
            return NoContent();

        }
        private Task<bool> AboutExists(int Id)
        {
            return _testimonialRepository.IsExistsAsync(a => a.TestimonialId == Id);
        }
    }
}
