using Inventory.DAL;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        => _context = context;
        public void Add(Order order)
        => _context.Orders.Add(order);


        public void Delete(Order order)
        => _context.Orders.Remove(order);


        public async Task<IReadOnlyList<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();


        public async Task<Order?> GetByIdAsync(int id)
        => await _context.Orders.FindAsync(id);


        public Task<int> SaveChangesAsync()
        => _context.SaveChangesAsync();

        public void Update(Order order)
        => _context.Orders.Update(order);


    }
}
