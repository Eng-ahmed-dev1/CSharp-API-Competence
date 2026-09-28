using ECommerec.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ECommerec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _context;
        public ProductController(IProductService context)
        => _context = context;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
        {
            var Products = await _context.GetAllAsync();
            return Ok(Products);
        }
        [HttpGet("less-than-2000")]
        [ProductLessThan2000]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllLessThan2000()
        {
            var Products = await _context.GetAllAsync();
            return Ok(Products);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductReadDto>> GetById(Guid id)
        {
            var Product = await _context.GetByIdAsync(id);
            return Ok(Product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Add(ProductCreateDto dto)
        {
            var created = await _context.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id = created.Id }, created);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductUpdateDto dto)
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