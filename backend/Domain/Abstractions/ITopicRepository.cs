using backend.Domain.Models;

namespace backend.Domain.Abstractions
{
    public interface ITopicRepository
    {
        Task<Guid> Create(Topic topic);
        Task<Guid> Delete(Guid id);
        Task<Topic> GetById(Guid id);
        Task<List<Topic>> List();
    }
}