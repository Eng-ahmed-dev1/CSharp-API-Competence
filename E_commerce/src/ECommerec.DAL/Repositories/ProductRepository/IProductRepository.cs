namespace ECommerec.DAL.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        void Add(Product category);
        void Update(Product category);
        void Delete(Product category);
        Task<int> SaveChangesAsync();
    }
}