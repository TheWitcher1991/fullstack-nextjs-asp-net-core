using backend.Domain.Models;

namespace backend.Domain.Abstractions
{
    public interface IAuthorRepository
    {
        Task<Guid> Create(Author author);
        Task<Guid> Delete(Guid id);
        Task<Author> GetById(Guid id);
        Task<List<Author>> List();
    }
}