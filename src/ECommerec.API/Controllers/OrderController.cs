using ECommerec.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ECommerec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _context;
        public OrderController(IOrderService context)
        => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll()
        {
            var Orders = await _context.GetAllAsync();
            return Ok(Orders);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderReadDto>> GetById(Guid id)
        {
            var Order = await _context.GetByIdAsync(id);
            return Ok(Order);
        }
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> Add(OrderCreateDto dto)
        {
            var created = await _context.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id = created.Id }, created);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, OrderUpdateDto dto)
        {
            await _context.UpdateAsync(id, dto);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _context.DeleteAsync(id);
            return NoContent();
        }
    }
}