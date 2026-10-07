using HR_System.BLL;
using HR_System.BLL.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _context;

        public EmployeesController(IEmployeeService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAll()
        {
            return Ok(await _context.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetById(int id)
        {
            var employee = await _context.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateDto employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            await _context.UpdateAsync(id, employee);

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<int>> Add(EmployeeWriteDto dto)
        {
            var employee = await _context.AddAsync(dto);
            return CreatedAtAction(nameof(GetById),
                new { id = employee },
                employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.DeleteAsync(id);
            if (!employee)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
