using backend.Abstractions;
using backend.Contracts;
using backend.Shared;
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
        public async Task<IResult> GetEmotions()
        {
            var emotions = await service.GetEmotions();

            return ResultResponse.Ok(emotions);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IResult> GetEmotion(Guid id)
        {
            return ResultResponse.Ok(await service.GetEmotion(id));
        }
    }
}
