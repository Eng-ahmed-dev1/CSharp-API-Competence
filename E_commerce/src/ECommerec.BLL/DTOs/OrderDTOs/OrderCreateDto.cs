using ECommerec.DAL;
namespace ECommerec.BLL
{
    public class OrderCreateDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

    }
}