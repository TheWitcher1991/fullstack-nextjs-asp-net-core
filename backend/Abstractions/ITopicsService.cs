using backend.Contracts;

namespace backend.Abstractions
{
    public interface ITopicsService
    {
        Task<Guid> CreateTopic(string title);
        Task<Guid> DeleteTopic(Guid id);
        Task<List<TopicDto>> GetAllTopics();
        Task<TopicDto> GetTopic(Guid id);
    }
}