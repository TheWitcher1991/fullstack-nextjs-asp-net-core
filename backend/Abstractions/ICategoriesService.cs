using backend.Contracts;

namespace backend.Abstractions
{
    public interface ICategoriesService
    {
        Task<Guid> CreateCategory(CreateCategoryDto dto);
        Task<Guid> DeleteCategory(Guid id);
        Task<List<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategory(Guid id);
    }
}