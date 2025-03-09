using AutoMapper;
using backend.Abstractions;
using backend.Contracts;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Book>> List(FilterBookDto query)
        {
            var bookQuery = _context.Books.AsNoTracking();

            if (!string.IsNullOrEmpty(query.search))
                bookQuery = bookQuery.Where(b => b.Title.ToLower().Contains(query.search.ToLower()));

            if (query.category.HasValue)
                bookQuery = bookQuery.Where(b => b.CategoryId == query.category.Value);

            if (query.minPrice.HasValue)
                bookQuery = bookQuery.Where(b => b.Price >= query.minPrice.Value);

            if (query.maxPrice.HasValue)
                bookQuery = bookQuery.Where(b => b.Price <= query.maxPrice.Value);

            if (query.ordering == "desc")
                bookQuery = bookQuery.OrderByDescending(b => b.CreatedAt);
            else
                bookQuery = bookQuery.OrderBy(b => b.CreatedAt);

            var bookEntities = await bookQuery
               .Skip((query.page - 1) * query.pageSize)
               .Take(query.pageSize)
               .ToListAsync();

            var books = bookEntities.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price, b.Category, b.User)).ToList();

            return books;
        }

        public async Task<Book> GetById(Guid id)
        {
            var bookEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Book>(bookEntity);
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Category = book.Category,
                User = book.User
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, UpdateBookDto book)
        {
            // var user = _context.Users.Where(u => u.Id == id).First();
            // var category = _context.Categories.Where(c => c.Id == id).First();

            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => book.title)
                    .SetProperty(b => b.Description, b => book.description)
                    .SetProperty(b => b.Price, b => book.price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
