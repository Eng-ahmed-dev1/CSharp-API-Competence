namespace ECommerec.BLL
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetAllAsync();
        Task<CategoryReadDto?> GetByIdAsync(Guid id);
        Task<CategoryReadDto> AddAsync(CategoryCreateDto dto);
        Task UpdateAsync(Guid id, CategoryUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}