using backend.Contracts;
using backend.Models;

namespace backend.Abstractions
{
    public interface ICategoriesService
    {
        Task<Guid> CreateCategory(CreateCategoryDto dto);
        Task<Guid> DeleteCategory(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(Guid id);
    }
}