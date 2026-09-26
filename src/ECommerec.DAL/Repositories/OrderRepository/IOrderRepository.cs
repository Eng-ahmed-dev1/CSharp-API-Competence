namespace ECommerec.DAL.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        void Add(Order category);
        void Update(Order category);
        void Delete(Order category);
        Task<int> SaveChangesAsync();
    }
}