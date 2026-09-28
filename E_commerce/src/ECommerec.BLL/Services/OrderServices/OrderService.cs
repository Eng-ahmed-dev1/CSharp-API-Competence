using ECommerec.DAL;
using ECommerec.DAL.Repositories.OrderRepository;
using Mapster;

namespace ECommerec.BLL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        => _repository = repository;

        public async Task<OrderReadDto> AddAsync(OrderCreateDto dto)
        {
            var order = dto.Adapt<Order>();
            _repository.Add(order);
            await _repository.SaveChangesAsync();
            return order.Adapt<OrderReadDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Order = await _repository.GetByIdAsync(id);
            //null العلامة دى ! انا حاطتها عشان انا اللى بدخل البيانات ف اانا بكدا بقوله انه اللى  جايلك  مش 
            _repository.Delete(Order!);
            await _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return orders.Adapt<IEnumerable<OrderReadDto>>();
        }
        public async Task<OrderReadDto?> GetByIdAsync(Guid id)
        {
            var Order = await _repository.GetByIdAsync(id);
            return Order.Adapt<OrderReadDto>();
        }
        public async Task UpdateAsync(Guid id, OrderUpdateDto dto)
        {
            var Order = await _repository.GetByIdAsync(id);
            dto.Adapt(Order);
            _repository.Update(Order!);
            await _repository.SaveChangesAsync();
        }
    }
}