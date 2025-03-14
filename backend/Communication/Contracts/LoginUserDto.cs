using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
{
    public record LoginUserDto(
        [Required] string Email,
        [Required] string Password
    );
}
