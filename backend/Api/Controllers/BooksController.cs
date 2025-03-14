using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService service;

        public BooksController(IBooksService booksService)
        {
            service = booksService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IResult> GetBooks([FromQuery] FilterBookDto query)
        {
            var books = await service.GetAllBooks(query);
            return ResultResponse.Ok();
        }

        [HttpGet("by-category")]
        [Authorize]
        public async Task<IResult> GetBooksByCategory([FromQuery] FilterBookDto query)
        {
            var categories = await service.GetBooksGroupedByCategory(query);

            return ResultResponse.Ok(categories);
        }

        [HttpGet("by-topic")]
        [Authorize]
        public async Task<IResult> GetBooksByTopic([FromQuery] FilterBookDto query)
        {
            var topics = await service.GetBooksGroupedByTopic(query);

            return ResultResponse.Ok(topics);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IResult> GetBook(Guid id)
        {
            return ResultResponse.Ok(await service.GetBook(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateBook([FromForm] CreateBookDto request)
        {
            var bookId = await service.CreateBook(request);

            return ResultResponse.Ok(bookId);
        }

        [HttpPatch("{id:guid}")]
        [Authorize]
        public async Task<IResult> UpdateBook(Guid id, [FromForm] UpdateBookDto request)
        {
            var bookId = await service.UpdateBook(id, request);

            return ResultResponse.Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IResult> DeleteBook(Guid id)
        {
            return ResultResponse.Ok(await service.DeleteBook(id));
        }
    }
}
