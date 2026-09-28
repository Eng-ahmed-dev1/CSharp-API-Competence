using ECommerec.DAL;

namespace ECommerec.BLL
{
    public class OrderUpdateDto
    {
        public OrderStatus Status { get; set; }
        public ICollection<OrderItemUpdateDto> OrderItems { get; set; } = new HashSet<OrderItemUpdateDto>();
    }
}