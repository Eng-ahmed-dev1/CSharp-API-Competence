using InventorySystem.BLL;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService product)
        {
            _service = product;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductReadDTO>>> GetAll(int pageNumber, int pageSize, string sortBy, bool desc)
        {
            return Ok(await _service.GetProductsAllAsync(pageNumber, pageSize, sortBy, desc));
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductReadDTO>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");
            var product = await _service.GetByIdAsync(id);
            if (product is null)
            {
                return BadRequest(new { msg = "The product not found" });
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Add(ProductCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var productId = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id = productId }, new { msg = "Created Successfully" });
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Update(int id, ProductUpdateDTO dto)
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