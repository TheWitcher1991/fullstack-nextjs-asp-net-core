using backend.Contracts;
using backend.Services;
using backend.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImpressionsController : ControllerBase
    {
        private readonly IImpressionsService service;

        public ImpressionsController(IImpressionsService impressionsService)
        {
            service = impressionsService;
        }

        [HttpGet("book/{id:guid}")]
        [Authorize]
        public async Task<IResult> GetImpressionsByBookId(Guid id)
        {
            var books = await service.GetImpressionsByBookId(id);

            return ResultResponse.Ok(books);
        }

        [HttpGet("user/{id:guid}")]
        [Authorize]
        public async Task<IResult> GetImpressionsByUserId(Guid id)
        {
            var books = await service.GetImpressionsByUserId(id);

            return ResultResponse.Ok(books);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IResult> GetImpression(Guid id)
        {
            return ResultResponse.Ok(await service.GetImpression(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateImpression([FromBody] CreateImpressionDto request)
        {
            var bookId = await service.CreateImpression(request);

            return ResultResponse.Ok(bookId);
        }

        [HttpPatch("{id:guid}")]
        [Authorize]
        public async Task<IResult> UpdateImpression(Guid id, [FromBody] UpdateImpressionDto request)
        {
            var bookId = await service.UpdateImpression(id, request);

            return ResultResponse.Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IResult> DeleteImpression(Guid id)
        {
            return ResultResponse.Ok(await service.DeleteImpression(id));
        }
    }
}
