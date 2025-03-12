using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record UserDto(
         Guid Id,
         [EmailAddress]
         string Email,
         [Phone]
         string Phone,
         string FirstName,
         string LastName,
         DateTime CreatedAt
     );
}
