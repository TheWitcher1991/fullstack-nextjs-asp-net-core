using backend.Abstractions;
using backend.Contracts;
using backend.Shared;
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
        public async Task<IResult> GetTopics()
        {
            var topics = await service.GetAllTopics();

            return ResultResponse.Ok(topics);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IResult> GetTopic(Guid id)
        {
            return ResultResponse.Ok(await service.GetTopic(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateTopic([FromBody] CreateTopicDto request)
        {
            var topicId = await service.CreateTopic(request.Title);

            return ResultResponse.Ok(topicId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IResult> DeleteTopic(Guid id)
        {
            return ResultResponse.Ok(await service.DeleteTopic(id));
        }
    }
}
