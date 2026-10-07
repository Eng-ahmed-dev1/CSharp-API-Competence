using Inventory.DAL;

namespace InventorySystem.BLL
{
    public class OrderCreateDTO
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.Confirmed;
        public List<OrderItemCreateDTO> Items { get; set; } = new();
    }
}