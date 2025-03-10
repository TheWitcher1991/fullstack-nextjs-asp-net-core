using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateBookDto(
        [Required] IFormFile Image,
        [Required] IFormFile File,
        [Required] string Title,
        [Required] string Description,
        [Required] decimal Price,
        [Required] Guid Category,
        [Required] Guid Topic,
        [Required] Guid User
    );
}
