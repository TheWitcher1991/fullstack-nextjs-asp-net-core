using backend.Abstractions;
using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository repository;
        private readonly IUserRepository _userRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BooksService(
            IBookRepository bookRepository,
            IUserRepository userRepository,
            ITopicRepository topicRepository,
            ICategoryRepository categoryRepository)
        {
            repository = bookRepository;
            _userRepository = userRepository;
            _topicRepository = topicRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Book>> GetAllBooks(FilterBookDto query)
        {
            return await repository.List(query);
        }

        public async Task<List<TopicBooksDto>> GetBooksGroupedByTopic(FilterBookDto query)
        {
            var books = await repository.List(query);
            var groupedBooks = books
                .GroupBy(b => b.Category)
                .Select(g => new TopicBooksDto(
                    g.Key.Id,
                    g.Key.Title,
                    g.Select(b => new BookDto(b.Id, b.Title, b.Description, b.Price, b.Topic, b.Category, b.User, b.CreatedAt)).ToList()
                ))
                .ToList();

            return groupedBooks;
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<Guid> CreateBook(CreateBookDto dto)
        {
            var topic = await _topicRepository.GetById(dto.Topic);
            var category = await _categoryRepository.GetById(dto.Category);
            var user = await _userRepository.GetById(dto.User);

            if (topic == null || category == null || user == null)
            {
                throw new Exception("Bad request");
            }

            var book = Book.Create(
                Guid.NewGuid(),
                dto.Title,
                dto.Description,
                dto.Price,
                topic,
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
