using Microsoft.EntityFrameworkCore;

namespace ECommerec.DAL.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        => _context = context;
        public void Add(Product Product)
        => _context.Products.Add(Product);
        public void Delete(Product Product)
        => _context.Remove(Product);
        public void Update(Product Product)
        => _context.Products.Update(Product);
        public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Products.AsNoTracking().ToListAsync();
        public async Task<Product?> GetByIdAsync(Guid id)
        => await _context.Products.FindAsync(id);
        public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
    }
}