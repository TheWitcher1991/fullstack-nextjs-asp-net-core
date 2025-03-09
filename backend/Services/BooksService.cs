using backend.Abstractions;
using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository repository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BooksService(IBookRepository bookRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            repository = bookRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Book>> GetAllBooks(FilterBookDto query)
        {
            return await repository.List(query);
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<Guid> CreateBook(CreateBookDto dto)
        {
            var category = await _categoryRepository.GetById(dto.category);
            var user = await _userRepository.GetById(dto.user);

            var book = Book.Create(
                Guid.NewGuid(),
                dto.title,
                dto.description,
                dto.price,
                category,
                user
            );

            return await repository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, UpdateBookDto book)
        {
            return await repository.Update(id, book);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await repository.Delete(id);
        }

    }
}
