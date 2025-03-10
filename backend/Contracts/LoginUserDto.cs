using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record LoginUserDto(
        [Required] string Email,
        [Required] string Password
    );
}
