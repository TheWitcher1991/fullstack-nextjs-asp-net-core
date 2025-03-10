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

            if (!string.IsNullOrEmpty(query.Search))
                bookQuery = bookQuery.Where(b => b.Title.ToLower().Contains(query.Search.ToLower()));

            if (query.Category.HasValue)
                bookQuery = bookQuery.Where(b => b.CategoryId == query.Category.Value);

            if (query.Topic.HasValue)
                bookQuery = bookQuery.Where(b => b.TopicId == query.Topic.Value);

            if (query.MinPrice.HasValue)
                bookQuery = bookQuery.Where(b => b.Price >= query.MinPrice.Value);

            if (query.MaxPrice.HasValue)
                bookQuery = bookQuery.Where(b => b.Price <= query.MaxPrice.Value);

            if (query.Ordering == "desc")
                bookQuery = bookQuery.OrderByDescending(b => b.CreatedAt);
            else
                bookQuery = bookQuery.OrderBy(b => b.CreatedAt);

            var bookEntities = await bookQuery
               .Skip((query.Page - 1) * query.PageSize)
               .Take(query.PageSize)
               .ToListAsync();

            var books = bookEntities.Select(b => Book.Create(
                b.Id, 
                b.ImagePath,
                b.FilePath,
                b.Title, 
                b.Description, 
                b.Price,
                _mapper.Map<Topic>(b.Topic),
                _mapper.Map<Category>(b.Category),
                _mapper.Map<User>(b.User)))
                .ToList();

            return books;
        }

        public async Task<Book> GetById(Guid id)
        {
            var bookEntity = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Book>(bookEntity);
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                ImagePath = book.ImagePath,
                FilePath = book.FilePath,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                TopicId = book.Topic.Id,
                CategoryId = book.Category.Id,
                UserId = book.User.Id
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, UpdateBookDto book, string ?imagePath, string? filePath)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => book.Title)
                    .SetProperty(b => b.Description, b => book.Description)
                    .SetProperty(b => b.Price, b => book.Price)
                    .SetProperty(b => b.ImagePath, b => imagePath ?? b.ImagePath)
                    .SetProperty(b => b.FilePath, b => filePath ?? b.FilePath));

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
