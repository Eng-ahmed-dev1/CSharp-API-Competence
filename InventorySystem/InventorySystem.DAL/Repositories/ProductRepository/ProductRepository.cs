using Inventory.DAL;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        => _context = context;
        public void Add(Product Product)
        => _context.Products.Add(Product);


        public void Delete(Product Product)
        => _context.Products.Remove(Product);


        public async Task<IReadOnlyList<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();


        public async Task<Product?> GetByIdAsync(int id)
        => await _context.Products.FindAsync(id);


        public Task<int> SaveChangesAsync()
        => _context.SaveChangesAsync();

        public void Update(Product Product)
        => _context.Products.Update(Product);


    }
}
