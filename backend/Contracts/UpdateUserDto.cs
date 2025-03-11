using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record UpdateUserDto(
        [Required]
        [EmailAddress] 
        string Email,

        [Required]
        string Phone,

        [Required]
        string FirstName,

        [Required]
        string LastName
     );
}
