namespace InventorySystem.BLL
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderReadDTO>> GetOrdersAllAsync();
        Task<OrderReadDTO> GetByIdAsync(int id);
        Task<int> AddAsync(OrderCreateDTO orderCreateDTO);
        Task<bool> UpdateAsync(int id, OrderUpdateDTO orderUpdateDTO);
        Task<bool> DeleteAsync(int id);
        Task<bool> CancelAsync(int id);
    }
}
