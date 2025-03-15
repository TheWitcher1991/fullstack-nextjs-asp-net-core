using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface IAuthorsService
    {
        Task<List<AuthorDto>> GetAllAuthors();
        Task<AuthorDto> GetAuthor(Guid id);
    }
}