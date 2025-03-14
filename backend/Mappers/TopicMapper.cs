using backend.Contracts;
using backend.Models;

namespace backend.Mappers
{
    public static class TopicMapper
    {
        public static TopicDto ToTopicDto(this Topic t)
        {
            return new TopicDto(
                t.Id,
                t.Title
            );
        }

        public static List<TopicDto> ToListTopicDto(this List<Topic> topics)
        {
            return topics.Select(i => i.ToTopicDto()).ToList();
        }
    }
}
