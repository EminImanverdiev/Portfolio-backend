using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities.DTOs.Services;
using PortfolioBackend.Entities;

namespace PortfolioBackend.Controllers
{
    [Authorize]
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
            var services = await _serviceRepository.GetAllAsync();
            if (services == null || !services.Any())
                return NotFound("No services found");

            var getServiceDtos = _mapper.Map<List<GetServiceDto>>(services);
            return Ok(getServiceDtos);
        }

        [HttpGet("GetService/{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var service = await _serviceRepository.GetAsync(s => s.ServiceId == id);
            if (service == null)
                return NotFound($"Service with ID {id} not found");

            var getServiceDto = _mapper.Map<GetServiceDto>(service);
            return Ok(getServiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            await _serviceRepository.AddAsync(service);
            await _serviceRepository.SaveAsync();
            return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, serviceDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceDto serviceDto)
        {
            var existingService = await _serviceRepository.GetAsync(s => s.ServiceId == serviceDto.ServiceId);
            if (existingService == null)
                return NotFound($"Service with ID {serviceDto.ServiceId} not found");

            _mapper.Map(serviceDto, existingService);
            _serviceRepository.Update(existingService);
            await _serviceRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingService = await _serviceRepository.GetAsync(s => s.ServiceId == id);
            if (existingService == null)
                return NotFound($"Service with ID {id} not found");

            _serviceRepository.Delete(existingService);
            await _serviceRepository.SaveAsync();
            return NoContent();
        }
    }
}
    