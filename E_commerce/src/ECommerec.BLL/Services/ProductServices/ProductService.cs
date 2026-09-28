using ECommerec.DAL;
using ECommerec.DAL.Repositories.ProductRepository;
using Mapster;

namespace ECommerec.BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        => _repository = repository;

        public async Task<ProductReadDto> AddAsync(ProductCreateDto dto)
        {
            var product = dto.Adapt<Product>();
            _repository.Add(product);
            await _repository.SaveChangesAsync();
            return product.Adapt<ProductReadDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Product = await _repository.GetByIdAsync(id);
            //null العلامة دى ! انا حاطتها عشان انا اللى بدخل البيانات ف اانا بكدا بقوله انه اللى  جايلك  مش 
            _repository.Delete(Product!);
            await _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var Products = await _repository.GetAllAsync();
            return Products.Adapt<IEnumerable<ProductReadDto>>();
        }
        public async Task<ProductReadDto?> GetByIdAsync(Guid id)
        {
            var Product = await _repository.GetByIdAsync(id);
            return Product.Adapt<ProductReadDto>();
        }
        public async Task UpdateAsync(Guid id, ProductUpdateDto dto)
        {
            var Product = await _repository.GetByIdAsync(id);
            dto.Adapt(Product);
            _repository.Update(Product!);
            await _repository.SaveChangesAsync();
        }
    }
}