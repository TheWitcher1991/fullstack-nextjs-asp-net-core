using backend.Contracts;
using backend.Models;

namespace backend.Abstractions
{
    public interface IImpressionRepository
    {
        Task<Guid> Create(Impression impression);
        Task<Guid> Delete(Guid id);
        Task<Impression> GetById(Guid id);
        Task<List<Impression>> ListByBookId(Guid bookId);
        Task<List<Impression>> ListByUserId(Guid userId);
        Task<Guid> Update(Guid id, UpdateImpressionDto impression);
    }
}