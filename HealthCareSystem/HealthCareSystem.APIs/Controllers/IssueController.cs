using HealthCareSystem.BL;
using HealthCareSystem.BL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _service;
        public IssueController(IIssueService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<IssueReadDTO>> GetAll()
        {
            var issues = _service.GetIssues();
            return Ok(issues);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IssueReadDTO> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var issue = _service.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }
            return Ok(issue);
        }

        [HttpPost]
        public ActionResult Create(IssueWriteDTO issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var issueId = _service.Add(issue);
            return CreatedAtAction(nameof(Get), new { id = issueId }, new { Message = "Created successfully" });
        }

        [HttpPut]
        public ActionResult Update(IssueUpdateDTO issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isUpdated = _service.Update(issue);
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
