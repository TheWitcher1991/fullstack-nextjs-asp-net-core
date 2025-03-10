using backend.Models;

namespace backend.Abstractions
{
    public interface ITopicsService
    {
        Task<Guid> CreateTopic(string title);
        Task<Guid> DeleteTopic(Guid id);
        Task<List<Topic>> GetAllTopics();
        Task<Topic> GetTopic(Guid id);
    }
}