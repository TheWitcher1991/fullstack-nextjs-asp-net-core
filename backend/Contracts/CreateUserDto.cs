using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateUserDto(
        [Required] string Email,
        [Required] string Phone,
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string Password
    );
}
