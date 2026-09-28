using HealthCareSystem.BL;
using HealthCareSystem.BL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<DoctorReadDTO>> GetAll()
        {
            var doctors = _service.GetDoctors();
            return Ok(doctors);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<DoctorReadDTO> Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var doctor = _service.GetById(id); 
            if(doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost]
        public ActionResult Create(DoctorWriteDTO doctor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var doctorId = _service.Add(doctor);
            return CreatedAtAction(nameof(Get), new { id = doctorId }, new {Message="Created successfully"});
        }

        [HttpPut]
        public ActionResult Update(DoctorUpdateDTO doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isUpdated = _service.Update(doctor);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var isDeleted = _service.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
