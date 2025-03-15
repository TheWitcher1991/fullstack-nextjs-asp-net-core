using backend.Domain.Abstractions;
using backend.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService service;

        public AuthorsController(IAuthorsService authorsService)
        {
            service = authorsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IResult> GetAuthors()
        {
            var authors = await service.GetAllAuthors();

            return ResultResponse.Ok(authors);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IResult> GetAuthor(Guid id)
        {
            return ResultResponse.Ok(await service.GetAuthor(id));
        }
    }
}
