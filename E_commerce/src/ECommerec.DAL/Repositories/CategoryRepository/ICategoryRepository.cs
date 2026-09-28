namespace ECommerec.DAL
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<int> SaveChangesAsync();
    }
}