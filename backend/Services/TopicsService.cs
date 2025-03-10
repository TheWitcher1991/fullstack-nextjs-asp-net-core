using backend.Abstractions;
using backend.Models;

namespace backend.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicRepository repository;

        public TopicsService(ITopicRepository topicRepository)
        {

            repository = topicRepository;
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            return await repository.List();
        }

        public async Task<Topic> GetTopic(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<Guid> CreateTopic(string title)
        {
            var category = Topic.Create(
                Guid.NewGuid(),
                title
            );

            return await repository.Create(category);
        }

        public async Task<Guid> DeleteTopic(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
