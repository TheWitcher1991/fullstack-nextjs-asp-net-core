using backend.Models;

namespace backend.Abstractions
{
    public interface ICategoriesService
    {
        Task<Guid> CreateCategory(string title);
        Task<Guid> DeleteCategory(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(Guid id);
    }
}