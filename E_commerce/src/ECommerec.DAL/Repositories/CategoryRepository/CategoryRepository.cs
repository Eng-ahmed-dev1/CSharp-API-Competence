using Microsoft.EntityFrameworkCore;

namespace ECommerec.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context) => _context = context;
        public async Task<IEnumerable<Category>> GetAllAsync()
        => await _context.Categories.AsNoTracking().ToListAsync();
        public async Task<Category?> GetByIdAsync(Guid id)
        => await _context.Categories.FindAsync(id);
        public void Add(Category category)
        => _context.Categories.Add(category);
        public void Update(Category category)
        => _context.Categories.Update(category);
        public void Delete(Category category)
        => _context.Categories.Remove(category);
        public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
    }
}