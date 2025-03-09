using backend.Models;

namespace backend.Services
{
    public interface ICategoryRepository
    {
        Task<Guid> Create(Category category);
        Task<Guid> Delete(Guid id);
        Task<Category> GetById(Guid id);
        Task<List<Category>> List();
    }
}