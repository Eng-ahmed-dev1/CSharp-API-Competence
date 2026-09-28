using ECommerec.DAL;
using Mapster;

namespace ECommerec.BLL
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<OrderItemReadDto, OrderItem>()
                .Map(dest => dest.Product.Name, src => src.ProductName);
            config.NewConfig<ProductReadDto, Product>()
                .Map(dest => dest.Category.Name, src => src.CategoryName);
        }
    }
}