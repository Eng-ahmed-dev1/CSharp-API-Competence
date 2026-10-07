using InventorySystem.BLL;
using InventorySystem.BLL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService Order)
        {
            _service = Order;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderReadDTO>>> GetAll()
        {
            return Ok(await _service.GetOrdersAllAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderReadDTO>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");
            var Order = await _service.GetByIdAsync(id);
            if (Order is null)
            {
                return BadRequest(new { msg = "The Order not found" });
            }
            return Ok(Order);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDTO dto)
        {
            try
            {
                var id = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id }, new { id });
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                return await _service.CancelAsync(id) ? NoContent() : NotFound();
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Update(int id, OrderUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id <= 0)
            {
                return BadRequest();
            }
            var isUpdated = await _service.UpdateAsync(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]

        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}