using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.Entities;
using PortfolioBackend.Entities.DTOs.Services;
using PortfolioBackend.Repositories.EFcore;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace PortfolioBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IResumeRepository _resumeRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;


        public ResumesController(IMapper mapper, IResumeRepository resumeRepository, IWebHostEnvironment environment,AppDbContext context)
        {
            _mapper = mapper;
            _resumeRepository = resumeRepository;
            _environment = environment;
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadResume([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya yüklemedi");

            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, file.FileName);

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var resume = new Resume
            {
                FileName = file.FileName,
                FilePath = $"/uploads/{file.FileName}",
                UploadedAt = DateTime.Now
            };

            await _resumeRepository.AddAsync(resume);
            await _resumeRepository.SaveAsync();

            return Ok(new { resume.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResumes()
        {
            var result = await _resumeRepository.GetAllAsync();
            if (result.Count == 0) return NotFound();
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResume(int id)
        {
            var resume = await _resumeRepository.GetAsync(c => c.Id == id);
            if (resume == null)
                return NotFound();

            var filePath = Path.Combine(_environment.WebRootPath, resume.FilePath.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            _resumeRepository.Delete(resume);
            await _resumeRepository.SaveAsync();
            return NoContent();
        }
    }
}
