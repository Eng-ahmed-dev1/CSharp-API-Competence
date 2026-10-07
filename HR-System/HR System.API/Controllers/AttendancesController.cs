using HR_System.BLL.DTOs.AttendanceDTOs;
using HR_System.BLL.DTOs.CheckInDTOs;
using HR_System.BLL.DTOs.CheckOutDTOs;
using HR_System.BLL.Services.IAttendanceServices;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _context;

        public AttendancesController(IAttendanceService context)
        {
            _context = context;
        }
        [HttpPost("check-out")]
        public async Task<ActionResult<CheckOutDto>> CheckOut(CheckOutDto dto)
        {
            var result = await _context.MakeCheckOut(dto);
            if (result == null)
                return BadRequest("Check-out failed: no check-in for this date, already checked out, or CheckOut is not after CheckIn");

            return Ok(result);
        }

        [HttpPost("check-in")]
        public async Task<ActionResult<CheckInDto>> CheckIn(CheckInDto dto)
        {
            var result = await _context.MakeCheckIn(dto);
            if (result == null)
                return BadRequest("Check-in failed: invalid employee, or already checked in on this date");

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceReadDto>>> GetAll()
        {
            return Ok(await _context.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceReadDto>> GetById(int id)
        {
            var Attendance = await _context.GetByIdAsync(id);

            if (Attendance == null)
            {
                return NotFound();
            }

            return Attendance;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AttendanceUpdateDto Attendance)
        {
            if (id != Attendance.Id)
            {
                return BadRequest();
            }
            await _context.UpdateAsync(id, Attendance);

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<int>> Add(AttendanceWriteDto dto)
        {
            var Attendance = await _context.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = Attendance }, Attendance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Attendance = await _context.DeleteAsync(id);
            if (!Attendance)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
