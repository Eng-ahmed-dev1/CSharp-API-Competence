using HealthCareSystem.BL;
using HealthCareSystem.BL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PatientReadDTO>> GetAll()
        {
            var patients = _service.GetPatients();
            return Ok(patients);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PatientReadDTO> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var patient = _service.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult Create(PatientWriteDTO patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var patientId = _service.Add(patient);
            return CreatedAtAction(nameof(Get), new { id = patientId }, new { Message = "Created successfully" });
        }

        [HttpPut]
        public ActionResult Update(PatientUpdateDTO patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isUpdated = _service.Update(patient);
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
