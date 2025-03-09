using backend.Abstractions;
using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books.AsNoTracking().ToListAsync();

            var books = bookEntities.Select(b => Book.Create(b.Title, b.Description, b.Price, b.Category, b.User).Book).ToList();

            return books;
        }

        public async Task<int> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
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

        public async Task<int> Update(int id, string title, string description, decimal price, Category category, User user)
        {
            // var user = _context.Users.Where(u => u.Id == id).First();
            // var category = _context.Categories.Where(c => c.Id == id).First();

            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price)
                    .SetProperty(b => b.Category, b => category)
                    .SetProperty(b => b.User, b => user));

            return id;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Books.Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
