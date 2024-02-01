using AutoMapper;
using BackendEmployee.Core.Context;
using BackendEmployee.Core.Dtos.Employee;
using BackendEmployee.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeCreateDto dto)
        {

            var newEmployee = _mapper.Map<Employee>(dto);
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return Ok("Employee Saved Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<EmployeeGetDto>>> GetEmployees()
        {
            var employees = await _context.Employees.OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedEmployees = _mapper.Map<IEnumerable<EmployeeGetDto>>(employees);

            return Ok(convertedEmployees);
        }

       

         //Read (Get Employee By ID)
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<EmployeeGetDto>> GetEMployeeById(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            var convertedEmployee = _mapper.Map<EmployeeGetDto>(employee);

            return Ok(convertedEmployee);
        }

        // Update
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateEmployee(long id, [FromBody] EmployeeUpdateDto dto)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);

            if (existingEmployee == null)
            {
                return NotFound("Employee Not Found");
            }

            // Update existingEmployee properties using dto...

            _context.Entry(existingEmployee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Employee Updated Successfully");
        }

        // Delete
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok("Employee Deleted Successfully");
        }
    }
}
