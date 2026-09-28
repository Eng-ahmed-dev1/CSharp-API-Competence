using ECommerec.DAL;
using Mapster;

namespace ECommerec.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        => _repository = repository;

        public async Task<CategoryReadDto> AddAsync(CategoryCreateDto dto)
        {
            var category = dto.Adapt<Category>();
            _repository.Add(category);
            await _repository.SaveChangesAsync();
            return category.Adapt<CategoryReadDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            //null العلامة دى ! انا حاطتها عشان انا اللى بدخل البيانات ف اانا بكدا بقوله انه اللى  جايلك  مش 
            _repository.Delete(category!);
            await _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Adapt<IEnumerable<CategoryReadDto>>();
        }
        public async Task<CategoryReadDto?> GetByIdAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            return category.Adapt<CategoryReadDto>();
        }
        public async Task UpdateAsync(Guid id, CategoryUpdateDto dto)
        {
            var category = await _repository.GetByIdAsync(id);
            dto.Adapt(category);
            _repository.Update(category!);
            await _repository.SaveChangesAsync();
        }
    }
}