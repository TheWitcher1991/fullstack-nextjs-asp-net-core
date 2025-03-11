using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record UpdateBookDto(
        IFormFile ?Image,
        IFormFile ?File,
        [Required] string Title,
        [Required] string Description,
        [Required] string Publisher,
        string? Holder,
        string? Translator,
        [Required] int Age,
        [Required] int Pages
    );
}
