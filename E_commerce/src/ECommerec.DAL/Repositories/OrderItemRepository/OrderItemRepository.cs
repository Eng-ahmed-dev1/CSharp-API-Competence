using Microsoft.EntityFrameworkCore;

namespace ECommerec.DAL
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly Context _context;
        public OrderItemRepository(Context context)
        => _context = context;
        public void Add(OrderItem orderItem)
        => _context.OrderItems.Add(orderItem);
        public void Delete(OrderItem orderItem)
        => _context.Remove(orderItem);
        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        => await _context.OrderItems.AsNoTracking().ToListAsync();
        public async Task<OrderItem?> GetByIdAsync(Guid id)
        => await _context.OrderItems.FindAsync(id);
        public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
        public void Update(OrderItem orderItem)
        => _context.OrderItems.Update(orderItem);
    }
}