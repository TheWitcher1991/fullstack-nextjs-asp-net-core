using backend.Abstractions;
using backend.Contracts;
using backend.Models;
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
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await service.GetAllBooks();

            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price, b.Category, b.User));

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> CreateBook([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                request.Title,
                request.Description,
                request.Price,
                request.Category,
                request.User
            );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await service.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPatch("{id:int}")]
        [Authorize]
        public async Task<ActionResult<int>> UpdateBook(int id, [FromBody] BooksRequest request)
        {
            var bookId = await service.UpdateBook(id, request.Title, request.Description, request.Price, request.Category, request.User);

            return Ok(bookId);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<int>> DeleteBook(int id)
        {
            return Ok(await service.DeleteBook(id));
        }
    }
}
