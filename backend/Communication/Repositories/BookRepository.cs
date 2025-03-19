using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain;
using backend.Domain.Abstractions;
using backend.Domain.Entities;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static backend.Domain.Permissions;

namespace backend.Communication.Repositories
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
            var bookQuery = _context.Books
                .AsNoTracking();

            if (!string.IsNullOrEmpty(query.Search))
                bookQuery = bookQuery.Where(b => b.Title.ToLower().Contains(query.Search.ToLower()));

            if (query.Category.HasValue)
                bookQuery = bookQuery.Where(b => b.Categories.Any(c => c.Id == query.Category.Value));

            if (query.Author.HasValue)
                bookQuery = bookQuery.Where(b => b.AuthorId == query.Author.Value);

            if (query.Ordering == "desc")
                bookQuery = bookQuery.OrderByDescending(b => b.CreatedAt);
            else
                bookQuery = bookQuery.OrderBy(b => b.CreatedAt);


            if (query.Page > 0 && query.PageSize > 0)
            {
                bookQuery = bookQuery
                    .Skip((query.Page - 1) * query.PageSize)
                    .Take(query.PageSize);
            }

            var bookEntities = await bookQuery
                .Include(b => b.User)
                .Include(b => b.Categories)
                .ToListAsync();

            var books = bookEntities.Select(b => Book.Create(
                b.Id,
                b.ImagePath,
                b.FilePath,
                b.Title,
                b.Description,
                b.Publisher,
                b.Age,
                b.Pages,
                _mapper.Map<User>(b.User),
                _mapper.Map<Author>(_context.Authors.AsNoTracking().FirstOrDefault(a => a.Id == b.AuthorId)),
                b.Categories.Select(c => _mapper.Map<Category>(c)).ToList(),
                b.Holder,
                b.Translator))
                .ToList();

            return books;
        }

        public async Task<Book> GetById(Guid id)
        {
            var bookEntity = await _context.Books
                .AsNoTracking()
                .Include(b => b.User)
                .Include(b => b.Categories)
                .Select(book => new BookEntity
                {
                    Id = book.Id,
                    ImagePath = book.ImagePath,
                    FilePath = book.FilePath,
                    Title = book.Title,
                    Description = book.Description,
                    Publisher = book.Publisher,
                    Holder = book.Holder,
                    Translator = book.Translator,
                    Age = book.Age,
                    Categories = book.Categories,
                    Pages = book.Pages,
                    User = book.User,
                    Author = _context.Authors.FirstOrDefault(a => a.Id == book.AuthorId) ?? new AuthorEntity()
                })
                .FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Book>(bookEntity);
        }

        public async Task<Guid> Create(Book book)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                var bookEntity = new BookEntity
                {
                    Id = book.Id,
                    ImagePath = book.ImagePath,
                    FilePath = book.FilePath,
                    Title = book.Title,
                    Description = book.Description,
                    Publisher = book.Publisher,
                    Holder = book.Holder,
                    Translator = book.Translator,
                    Age = book.Age,
                    Pages = book.Pages,
                    UserId = book.User.Id,
                    AuthorId = book.Author.Id,
                };

                foreach (var category in book.Categories)
                {
                    var existingCategory = await _context.Categories.FindAsync(category.Id);
                    if (existingCategory == null)
                    {
                        throw new BadHttpRequestException($"Category with ID {category.Id} not found.");
                    }
                    bookEntity.Categories.Add(existingCategory);
                }

                await _context.Books.AddAsync(bookEntity);
                await _context.SaveChangesAsync();
                transaction.Commit();

                return bookEntity.Id;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new BadHttpRequestException(e.ToString());
            }
        }

        public async Task<Guid> Update(Guid id, UpdateBookDto book, string? imagePath, string? filePath)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => book.Title)
                    .SetProperty(b => b.Description, b => book.Description)
                    .SetProperty(b => b.Publisher, b => book.Publisher)
                    .SetProperty(b => b.Translator, b => book.Translator)
                    .SetProperty(b => b.Holder, b => book.Holder)
                    .SetProperty(b => b.Age, b => book.Age)
                    .SetProperty(b => b.Pages, b => book.Pages)
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
