using Inventory.DAL;
using InventorySystem.DAL;

namespace InventorySystem.BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _context;
        public ProductService(IProductRepository product)
        {
            _context = product;
        }
        public async Task<int> AddAsync(ProductCreateDTO dto)
        {
            if (dto is null)
                return -1;
            var product = new Product
            {
                Category = dto.Category,
                Description = dto.Description,
                IsActive = dto.IsActive,
                StockQuantity = dto.StockQuantity,
                Name = dto.Name,
                Price = dto.Price
            };
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.GetByIdAsync(id);
            if (product is null)
                return false;
            _context.Delete(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductReadDTO> GetByIdAsync(int id)
        {
            var Product = await _context.GetByIdAsync(id);
            if (Product is null)
                return null!;
            return new ProductReadDTO
            {
                Category = Product.Category,
                Description = Product.Description,
                IsActive = Product.IsActive,
                Name = Product.Name,
                Price = Product.Price,
                StockQuantity = Product.StockQuantity,
                Id = Product.Id
            };
        }

        public async Task<IReadOnlyList<ProductReadDTO>> GetProductsAllAsync(int pageNumber, int pageSize, string sortBy = "Id", bool desc = false)
        {

            pageNumber = Math.Max(pageNumber, 1);
            pageSize = Math.Clamp(pageSize, 1, 50);

            IEnumerable<Product> Products = await _context.GetAllAsync();

            Products = sortBy.ToLower() switch
            {
                "name" => desc
                    ? Products.OrderByDescending(x => x.Name).ThenBy(x => x.Id)
                    : Products.OrderBy(x => x.Name).ThenBy(x => x.Id),
                "price" => desc
                    ? Products.OrderByDescending(p => p.Price).ThenBy(p => p.Id)
                    : Products.OrderBy(p => p.Price).ThenBy(p => p.Id),
                "stock" => desc
                    ? Products.OrderByDescending(x => x.StockQuantity).ThenBy(x => x.Id)
                    : Products.OrderBy(x => x.StockQuantity).ThenBy(x => x.Id),
                _ => desc
                    ? Products.OrderByDescending(i => i.Id)
                    : Products.OrderBy(i => i.Id)

            };
            return Products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new ProductReadDTO
            {
                Category = x.Category,
                Description = x.Description,
                IsActive = x.IsActive,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                Id = x.Id
            }).ToList();
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDTO ProductUpdateDTO)
        {
            if (ProductUpdateDTO is null)
                return false;
            var Product = await _context.GetByIdAsync(id);
            if (Product is null)
                return false;

            ProductUpdateDTO.Category = Product.Category;
            ProductUpdateDTO.Description = Product.Description;
            ProductUpdateDTO.IsActive = Product.IsActive;
            ProductUpdateDTO.Price = Product.Price;
            ProductUpdateDTO.Name = Product.Name;
            ProductUpdateDTO.StockQuantity = Product.StockQuantity;

            _context.Update(Product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
