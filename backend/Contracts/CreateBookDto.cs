using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateBookDto(
        [Required] string title,
        [Required] string description,
        [Required] decimal price,
        [Required] Guid category,
        [Required] Guid user
    );
}
