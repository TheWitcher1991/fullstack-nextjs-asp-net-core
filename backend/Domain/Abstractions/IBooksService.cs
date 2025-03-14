using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(CreateBookDto dto);
        Task<Guid> DeleteBook(Guid id);
        Task<List<BookDto>> GetAllBooks(FilterBookDto query);
        Task<BookDto> GetBook(Guid id);
        Task<List<CategoryBooksDto>> GetBooksGroupedByCategory(FilterBookDto query);
        Task<List<TopicBooksDto>> GetBooksGroupedByTopic(FilterBookDto query);
        Task<Guid> UpdateBook(Guid id, UpdateBookDto book);
    }
}