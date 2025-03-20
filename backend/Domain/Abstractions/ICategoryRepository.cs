using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Abstractions
{
    public interface ICategoryRepository
    {
        Task<Guid> Create(Category category);
        Task<Guid> Delete(Guid id);
        Task<List<Category>> GetByIds(List<Guid> ids);
        Task<Category> GetById(Guid id);
        Task<List<Category>> List(FilterCategoryDto query);
    }
}