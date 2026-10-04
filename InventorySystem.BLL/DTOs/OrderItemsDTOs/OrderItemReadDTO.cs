using Inventory.DAL;

namespace InventorySystem.BLL
{
    public class OrderItemReadDTO
    {
        public int Id { get; set; } 
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
