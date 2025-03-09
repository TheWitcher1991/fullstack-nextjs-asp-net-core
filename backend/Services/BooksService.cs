using backend.Abstractions;
using backend.Models;

namespace backend.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository repository;

        public BooksService(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await repository.Get();
        }

        public async Task<int> CreateBook(Book book)
        {
            return await repository.Create(book);
        }

        public async Task<int> UpdateBook(int id, string title, string description, decimal price, Category category, User user)
        {
            return await repository.Update(id, title, description, price, category, user);
        }

        public async Task<int> DeleteBook(int id)
        {
            return await repository.Delete(id);
        }

    }
}
