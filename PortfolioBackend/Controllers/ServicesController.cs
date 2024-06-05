using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities.DTOs.Contacts;
using PortfolioBackend.Entities;
using PortfolioBackend.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.Entities.DTOs.Abouts;
using PortfolioBackend.Entities.DTOs.Services;

namespace PortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServicesController(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        [HttpGet("GetServices")]

        public async Task<IActionResult> GetServices()
        {
            var result = await _serviceRepository.GetAllAsync();
            List<GetServiceDto> getservicedtos = _mapper.Map<List<GetServiceDto>>(result);
            if (result.Count == 0) return NotFound();
            return Ok(getservicedtos);

        }
        [HttpGet("GetService/{Id}")]
        public async Task<IActionResult> GetService(int Id)
        {
            var result = await _serviceRepository.GetAsync(s => s.ServiceId == Id);
            GetServiceDto getServiceDto = _mapper.Map<GetServiceDto>(result);
            if (result is null) return NotFound();
            return Ok(getServiceDto);

        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(CreateServiceDto serviceDto)
        {
            Service service = _mapper.Map<Service>(serviceDto);
            await _serviceRepository.AddAsync(service);
            await _serviceRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceDto serviceDto)
        {
            if (!await ServiceExists(serviceDto.ServiceId)) return NotFound();

            Service service = _mapper.Map<Service>(serviceDto);
            _serviceRepository.Update(service);

            await _serviceRepository.SaveAsync();
            return NoContent();
        }
        [HttpDelete("De lete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (_serviceRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var result = await _serviceRepository.GetAsync(s => s.ServiceId == Id);
            if (result is null) return BadRequest();
            _serviceRepository.Delete(result);
            await _serviceRepository.SaveAsync();
            return NoContent();

        }
        private Task<bool> ServiceExists(int Id)
        {
            return _serviceRepository.IsExistsAsync(s => s.ServiceId == Id);
        }
    }
}
