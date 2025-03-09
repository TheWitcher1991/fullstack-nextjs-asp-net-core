using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record LoginUserDto(
        [Required] string email,
        [Required] string password
    );
}
