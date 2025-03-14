using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
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
