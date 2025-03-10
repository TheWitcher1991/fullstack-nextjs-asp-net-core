using backend.Abstractions;
using backend.Contracts;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
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
        public async Task<ActionResult<List<BookDto>>> GetBooks([FromQuery] FilterBookDto query)
        {
            var books = await service.GetAllBooks(query);

            var response = books.Select(b => new BookDto(b.Id, b.Title, b.Description, b.Price, b.Topic, b.Category, b.User, b.CreatedAt));

            return Ok(response);
        }

        [HttpGet("by-topic")]
        public async Task<ActionResult<List<TopicBooksDto>>> GetBooksByTopic([FromQuery] FilterBookDto query)
        {
            var topics = await service.GetBooksGroupedByTopic(query);

            return Ok(topics);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<BookDto>> GetBook(Guid id)
        {
            return Ok(await service.GetBook(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] CreateBookDto request)
        {
            var bookId = await service.CreateBook(request);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] UpdateBookDto request)
        {
            var bookId = await service.UpdateBook(id, request);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(await service.DeleteBook(id));
        }
    }
}
