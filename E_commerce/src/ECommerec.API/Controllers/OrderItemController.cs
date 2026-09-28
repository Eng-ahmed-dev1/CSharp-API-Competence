using ECommerec.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ECommerec.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _context;
        public OrderItemController(IOrderItemService context)
        => _context = context;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemReadDto>>> GetAll()
        {
            var OrderItems = await _context.GetAllAsync();
            return Ok(OrderItems);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderItemReadDto>> GetById(Guid id)
        {
            var OrderItem = await _context.GetByIdAsync(id);
            return Ok(OrderItem);
        }
        [HttpPost]
        public async Task<ActionResult<OrderItemReadDto>> Add(OrderItemCreateDto dto)
        {
            var created = await _context.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id = created.Id }, created);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, OrderItemUpdateDto dto)
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