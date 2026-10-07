using Inventory.DAL;

namespace InventorySystem.BLL
{
    public class OrderWithOrderItems
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public ICollection<OrderItemReadDTO> Items { get; set; } = new HashSet<OrderItemReadDTO>();
    }
}
