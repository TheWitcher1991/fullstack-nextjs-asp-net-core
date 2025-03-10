using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(CreateBookDto dto);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks(FilterBookDto query);
        Task<Book> GetBook(Guid id);
        Task<List<TopicBooksDto>> GetBooksGroupedByTopic(FilterBookDto query);
        Task<Guid> UpdateBook(Guid id, UpdateBookDto book);
    }
}