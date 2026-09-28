namespace ECommerec.BLL
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemReadDto>> GetAllAsync();
        Task<OrderItemReadDto?> GetByIdAsync(Guid id);
        Task<OrderItemReadDto> AddAsync(OrderItemCreateDto dto);
        Task UpdateAsync(Guid id, OrderItemUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}