using backend.Contracts;
using backend.Models;

namespace backend.Abstractions
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<Book> GetById(Guid id);
        Task<List<Book>> List(FilterBookDto query);
        Task<Guid> Update(Guid id, UpdateBookDto book);
    }
}