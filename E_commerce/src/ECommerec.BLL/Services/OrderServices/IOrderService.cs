namespace ECommerec.BLL
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto?> GetByIdAsync(Guid id);
        Task<OrderReadDto> AddAsync(OrderCreateDto dto);
        Task UpdateAsync(Guid id, OrderUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}