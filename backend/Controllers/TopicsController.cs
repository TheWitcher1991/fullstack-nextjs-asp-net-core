using backend.Abstractions;
using backend.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicsService service;

        public TopicsController(ITopicsService topicsService)
        {
            service = topicsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TopicDto>>> GetTopics()
        {
            var topics = await service.GetAllTopics();

            return Ok(topics);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<TopicDto>> GetTopic(Guid id)
        {
            return Ok(await service.GetTopic(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateTopic([FromBody] CreateTopicDto request)
        {
            var topicId = await service.CreateTopic(request.Title);

            return Ok(topicId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> DeleteTopic(Guid id)
        {
            return Ok(await service.DeleteTopic(id));
        }
    }
}
