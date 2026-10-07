namespace InventorySystem.BLL
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductReadDTO>> GetProductsAllAsync(int pageNumber, int pageSize, string sortBy = "Id", bool desc = false);
        Task<ProductReadDTO> GetByIdAsync(int id);
        Task<int> AddAsync(ProductCreateDTO ProductCreateDTO);
        Task<bool> UpdateAsync(int id, ProductUpdateDTO ProductUpdateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
