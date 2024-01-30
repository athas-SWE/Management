using AutoMapper;
using BackendEmployee.Core.Context;
using BackendEmployee.Core.Dtos.Department;
using BackendEmployee.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }
            
        public DepartmentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD 

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentCreateDto dto)
        {
            Department newDepartment = _mapper.Map<Department>(dto);
            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();

            return Ok("Department Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetDepartments()
        {
            var departments = await _context.Departments.OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedCompanies = _mapper.Map<IEnumerable<DepartmentGetDto>>(departments);

            return Ok(convertedCompanies);
        }

        // Read (Get Department By ID)

        // Update 

        // Delete

    }
}
