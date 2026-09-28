namespace ECommerec.BLL
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetAllAsync();
        Task<ProductReadDto?> GetByIdAsync(Guid id);
        Task<ProductReadDto> AddAsync(ProductCreateDto dto);
        Task UpdateAsync(Guid id, ProductUpdateDto dto);
        Task DeleteAsync(Guid id);

    }
}