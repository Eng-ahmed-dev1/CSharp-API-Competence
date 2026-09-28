using ECommerec.DAL;

namespace ECommerec.BLL
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}