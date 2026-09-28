using Microsoft.EntityFrameworkCore;

namespace ECommerec.DAL.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        public OrderRepository(Context context)
        => _context = context;
        public void Add(Order Order)
        => _context.Orders.Add(Order);
        public void Delete(Order Order)
        => _context.Remove(Order);
        public void Update(Order Order)
        => _context.Orders.Update(Order);
        public async Task<IEnumerable<Order>> GetAllAsync()
        => await _context.Orders.AsNoTracking().ToListAsync();
        public async Task<Order?> GetByIdAsync(Guid id)
        => await _context.Orders.FindAsync(id);
        public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
    }
}