﻿using backend.Contracts;
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
        public async Task<ActionResult> GetBooks([FromQuery] FilterBookDto query)
        {
            var books = await service.GetAllBooks(query);
            return Ok(books);
        }

        [HttpGet("by-category")]
        [Authorize]
        public async Task<ActionResult> GetBooksByCategory([FromQuery] FilterBookDto query)
        {
            var categories = await service.GetBooksGroupedByCategory(query);

            return Ok(categories);
        }

        [HttpGet("by-topic")]
        [Authorize]
        public async Task<ActionResult> GetBooksByTopic([FromQuery] FilterBookDto query)
        {
            var topics = await service.GetBooksGroupedByTopic(query);

            return Ok(topics);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult> GetBook(Guid id)
        {
            return Ok(await service.GetBook(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateBook([FromForm] CreateBookDto request)
        {
            var bookId = await service.CreateBook(request);

            return Ok(bookId);
        }

        [HttpPatch("{id:guid}")]
        [Authorize]
        public async Task<ActionResult> UpdateBook(Guid id, [FromForm] UpdateBookDto request)
        {
            var bookId = await service.UpdateBook(id, request);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            return Ok(await service.DeleteBook(id));
        }
    }
}
