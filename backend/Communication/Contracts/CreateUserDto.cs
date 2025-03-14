using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
{
    public record CreateUserDto(
        [Required, EmailAddress]
        string Email,

        [Required, Phone]
        string Phone,

        [Required]
        string FirstName,

        [Required]
        string LastName,

        [Required]
        string Password
    );
}
