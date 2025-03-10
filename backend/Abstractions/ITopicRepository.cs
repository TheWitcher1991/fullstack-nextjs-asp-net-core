using backend.Models;

namespace backend.Abstractions
{
    public interface ITopicRepository
    {
        Task<Guid> Create(Topic topic);
        Task<Guid> Delete(Guid id);
        Task<Topic> GetById(Guid id);
        Task<List<Topic>> List();
    }
}