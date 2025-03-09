using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateUserDto(
        [Required] string email,
        [Required] string phone,
        [Required] string firstName,
        [Required] string lastName,
        [Required] string password
    );
}
