using Inventory.DAL;
using InventorySystem.BLL.Exceptions;
using InventorySystem.DAL;

namespace InventorySystem.BLL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _context;
        private readonly IProductRepository _products;

        public OrderService(IOrderRepository order, IProductRepository products)
        {
            _context = order;
            _products = products;
        }
        public async Task<int> AddAsync(OrderCreateDTO dto)
        {
            if (dto is null || dto.Items.Count == 0)
                throw new BusinessRuleException("Order must contain at least one item.");

            var order = new Order
            {
                CustomerName = dto.CustomerName,
                CustomerPhone = dto.CustomerPhone,
                ShippingAddress = dto.ShippingAddress,
                PaymentMethod = dto.PaymentMethod,
                Status = dto.Status
            };

            foreach (var item in dto.Items)
            {
                if (item.Quantity <= 0)
                    throw new BusinessRuleException("Quantity must be greater than zero.");

                var product = await _products.GetByIdAsync(item.ProductId);
                if (product is null)
                    throw new BusinessRuleException($"Product {item.ProductId} not found.");

                if (product.StockQuantity < item.Quantity)
                    throw new BusinessRuleException(
                        $"Not enough stock for '{product.Name}'. Available: {product.StockQuantity}, requested: {item.Quantity}.");

                product.StockQuantity -= item.Quantity;

                order.Items.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });

                order.TotalAmount += product.Price * item.Quantity;
            }

            _context.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<bool> CancelAsync(int id)
        {
            var order = await _context.GetByIdWithItemsAsync(id);
            if (order is null)
                return false;

            if (order.Status == OrderStatus.Cancelled)
                throw new BusinessRuleException("Order is already cancelled.");

            foreach (var item in order.Items)
            {
                var product = await _products.GetByIdAsync(item.ProductId);
                if (product is not null)
                    product.StockQuantity += item.Quantity;
            }

            order.Status = OrderStatus.Cancelled;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var order = await _context.GetByIdAsync(id);
            if (order is null)
                return false;
            _context.Delete(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OrderReadDTO> GetByIdAsync(int id)
        {
            var order = await _context.GetByIdWithItemsAsync(id);
            if (order is null)
                return null!;

            return new OrderReadDTO
            {
                CustomerName = order.CustomerName,
                CustomerPhone = order.CustomerPhone,
                PaymentMethod = order.PaymentMethod,
                ShippingAddress = order.ShippingAddress,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                Id = order.Id,
                Items = order.Items.Select(i => new OrderItemReadDTO
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
        public async Task<IReadOnlyList<OrderReadDTO>> GetOrdersAllAsync()
        {
            return (await _context.GetAllAsync()).Select(c => new OrderReadDTO
            {
                CustomerName = c.CustomerName,
                CustomerPhone = c.CustomerPhone,
                PaymentMethod = c.PaymentMethod,
                ShippingAddress = c.ShippingAddress,
                Status = c.Status,
                TotalAmount = c.TotalAmount,
                Id = c.Id,
                Items = c.Items.Select(i => new OrderItemReadDTO
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }
        public async Task<bool> UpdateAsync(int id, OrderUpdateDTO orderUpdateDTO)
        {
            if (orderUpdateDTO is null)
                return false;
            var order = await _context.GetByIdAsync(id);
            if (order is null)
                return false;
            order.CustomerName = orderUpdateDTO.CustomerName;
            order.CustomerPhone = orderUpdateDTO.CustomerPhone;
            order.ShippingAddress = orderUpdateDTO.ShippingAddress;
            order.PaymentMethod = orderUpdateDTO.PaymentMethod;

            _context.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
