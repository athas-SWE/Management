using AutoMapper;
using BackendEmployee.Core.Context;
//using BackendEmployee.Core.Dtos.Department;
using BackendEmployee.Core.Dtos.Job;
using BackendEmployee.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD 

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();

            return Ok("Job Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await _context.Jobs.Include(job => job.Department).OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertdJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(convertdJobs);
        }

        // Read (Get Job By ID)
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<JobGetDto>> GetJobById(long id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound("Job not found");
            }

            var convertedJob = _mapper.Map<JobGetDto>(job);

            return Ok(convertedJob);
        }

        // Update 
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateJob(long id, [FromBody] JobUpdateDto dto)
        {
            var existingJob = await _context.Jobs.FindAsync(id);

            if (existingJob == null)
            {
                return NotFound("Job not found");
            }

            _mapper.Map<JobUpdateDto, Job>(dto, existingJob);

            await _context.SaveChangesAsync();

            return Ok("Job Updated Successfully");
        }

        // Delete
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            var jobToDelete = await _context.Jobs.FindAsync(id);

            if (jobToDelete == null)
            {
                return NotFound("Job not found");
            }

            _context.Jobs.Remove(jobToDelete);
            await _context.SaveChangesAsync();

            return Ok("Job deleted successfully");
        }
    }
}
