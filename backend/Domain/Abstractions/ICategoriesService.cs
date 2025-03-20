using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface ICategoriesService
    {
        Task<Guid> CreateCategory(CreateCategoryDto dto);
        Task<Guid> DeleteCategory(Guid id);
        Task<List<CategoryDto>> GetAllCategories(FilterCategoryDto query);
        Task<CategoryDto> GetCategory(Guid id);
    }
}