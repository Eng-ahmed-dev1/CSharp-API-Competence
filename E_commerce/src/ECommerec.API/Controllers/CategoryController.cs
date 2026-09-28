using ECommerec.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ECommerec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _context;
        public CategoryController(ICategoryService category) => _context = category;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAll()
        {
            var categories = await _context.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryReadDto>> GetById(Guid id)
        {
            var Category = await _context.GetByIdAsync(id);
            if (Category is null)
                return NotFound();
            return Ok(Category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> Add(CategoryCreateDto dto)
        {
            var created = await _context.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, CategoryUpdateDto dto)
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