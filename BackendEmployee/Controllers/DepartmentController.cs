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
            var convertedDepartments = _mapper.Map<IEnumerable<DepartmentGetDto>>(departments);

            return Ok(convertedDepartments);
        }

        // Read (Get Department By ID)
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<DepartmentGetDto>> GetDepartmentById(long id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            var convertedDepartment = _mapper.Map<DepartmentGetDto>(department);

            return Ok(convertedDepartment);
        }


        // Update 
        [HttpPut]
        [Route("Update/{departmentId}")]
        public async Task<IActionResult> UpdateDepartment(int departmentId, [FromBody] DepartmentUpdateDto dto)
        {
            var existingDepartment = await _context.Departments.FindAsync(departmentId);

            if (existingDepartment == null)
            {
                return NotFound("Department not found");
            }

            _mapper.Map(dto, existingDepartment);
            await _context.SaveChangesAsync();

            return Ok("Department Updated Successfully");
        }

        // Delete
        [HttpDelete]
        [Route("Delete/{departmentId}")]
        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            var existingDepartment = await _context.Departments.FindAsync(departmentId);

            if (existingDepartment == null)
            {
                return NotFound("Department not found");
            }

            _context.Departments.Remove(existingDepartment);
            await _context.SaveChangesAsync();

            return Ok("Department Deleted Successfully");
        }

    }
}
