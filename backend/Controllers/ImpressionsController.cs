using backend.Abstractions;
using backend.Contracts;
using backend.Services;
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
        public async Task<ActionResult<List<ImpressionDto>>> GetImpressionsByBookId(Guid id)
        {
            var books = await service.GetImpressionsByBookId(id);

            return Ok(books);
        }

        [HttpGet("user/{id:guid}")]
        [Authorize]
        public async Task<ActionResult<List<ImpressionDto>>> GetImpressionsByUserId(Guid id)
        {
            var books = await service.GetImpressionsByUserId(id);

            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ImpressionDto>> GetImpression(Guid id)
        {
            return Ok(await service.GetImpression(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateImpression([FromForm] CreateImpressionDto request)
        {
            var bookId = await service.CreateImpression(request);

            return Ok(bookId);
        }

        [HttpPatch("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> UpdateImpression(Guid id, [FromForm] UpdateImpressionDto request)
        {
            var bookId = await service.UpdateImpression(id, request);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> DeleteImpression(Guid id)
        {
            return Ok(await service.DeleteImpression(id));
        }
    }
}
