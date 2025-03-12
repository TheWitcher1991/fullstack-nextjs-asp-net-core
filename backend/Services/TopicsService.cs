using AutoMapper;
using backend.Abstractions;
using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicRepository repository;
        private readonly IMapper _mapper;

        public TopicsService(ITopicRepository topicRepository, IMapper mapper)
        {
            repository = topicRepository;
            _mapper = mapper;
        }

        public async Task<List<TopicDto>> GetAllTopics()
        {
            var topics = await repository.List();
            return topics.Select(t => new TopicDto(t.Id, t.Title)).ToList();
        }

        public async Task<TopicDto> GetTopic(Guid id)
        {
            var topic = await repository.GetById(id);
            return _mapper.Map<TopicDto>(topic);
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
