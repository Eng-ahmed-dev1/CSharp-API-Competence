using Inventory.DAL;

namespace InventorySystem.DAL
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetAllAsync();
        Task<Order?> GetByIdWithItemsAsync(int id);
        Task<Order?> GetByIdAsync(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        Task<int> SaveChangesAsync();
    }
}
