using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public interface IBooksService1
    {
        Task<Guid> CreateBook(CreateBookDto dto);
        Task<Guid> DeleteBook(Guid id);
        Task<List<BookDto>> GetAllBooks(FilterBookDto query);
        Task<Book> GetBook(Guid id);
        Task<List<TopicBooksDto>> GetBooksGroupedByTopic(FilterBookDto query);
        Task<Guid> UpdateBook(Guid id, UpdateBookDto book);
    }
}