using backend.Abstractions;
using backend.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmotionsController : ControllerBase
    {
        private readonly IEmotionsService service;

        public EmotionsController(IEmotionsService emotionsService)
        {
            service = emotionsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<EmotionDto>>> GetEmotions()
        {
            var emotions = await service.GetEmotions();

            return Ok(emotions);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<EmotionDto>> GetEmotion(Guid id)
        {
            return Ok(await service.GetEmotion(id));
        }
    }
}
