using ECommerec.DAL;
using Mapster;

namespace ECommerec.BLL
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        public OrderItemService(IOrderItemRepository repository) => _repository = repository;
        public async Task<OrderItemReadDto> AddAsync(OrderItemCreateDto dto)
        {
            OrderItem orderItem = dto.Adapt<OrderItem>();
            _repository.Add(orderItem);
            await _repository.SaveChangesAsync();
            return orderItem.Adapt<OrderItemReadDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderItem = await _repository.GetByIdAsync(id);
            _repository.Delete(orderItem!);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItemReadDto>> GetAllAsync()
        {
            var OrderItems = await _repository.GetAllAsync();
            return OrderItems.Adapt<IEnumerable<OrderItemReadDto>>();
        }

        public async Task<OrderItemReadDto?> GetByIdAsync(Guid id)
        {
            var OrderItem = await _repository.GetByIdAsync(id);
            return OrderItem.Adapt<OrderItemReadDto>();

        }

        public async Task UpdateAsync(Guid id, OrderItemUpdateDto dto)
        {
            var OrderItem = await _repository.GetByIdAsync(id);
            dto.Adapt(OrderItem);
            _repository.Update(OrderItem!);
            await _repository.SaveChangesAsync();

        }
    }
}