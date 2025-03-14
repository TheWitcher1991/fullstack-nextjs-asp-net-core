using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Abstractions
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<Book> GetById(Guid id);
        Task<List<Book>> List(FilterBookDto query);
        Task<Guid> Update(Guid id, UpdateBookDto book, string? imagePath, string? filePath);
    }
}