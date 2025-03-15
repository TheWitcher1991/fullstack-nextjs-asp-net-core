using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author a)
        {
            return new AuthorDto(
                a.Id,
                a.FullName,
                a.About,
                a.AvatarPath,
                a.CreatedAt
            );
        }

        public static List<AuthorDto> ToListAuthorDto(this List<Author> authors)
        {
            return authors.Select(a => a.ToAuthorDto()).ToList();
        }
    }
}
