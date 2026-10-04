namespace InventorySystem.BLL
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderReadDTO>> GetOrdersAllAsync();
        Task<OrderReadDTO> GetByIdAsync(long id);

        Task<int> AddAsync(OrderCreateDTO orderCreateDTO);
        Task<bool> UpdateAsync(int id,OrderUpdateDTO orderUpdateDTO);
        Task<int> DeleteAsync(int id);
    }
}
