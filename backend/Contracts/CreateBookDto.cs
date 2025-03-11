using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateBookDto(
        [Required] IFormFile Image,
        [Required] IFormFile File,
        [Required] string Title,
        [Required] string Description,
        [Required] string Publisher,
        string? Holder,
        string? Translator,
        [Required] int Age,
        [Required] int Pages,
        [Required] List<Guid> Categories,
        [Required] Guid User
    );
}
