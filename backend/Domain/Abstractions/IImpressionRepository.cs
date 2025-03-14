using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Abstractions
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