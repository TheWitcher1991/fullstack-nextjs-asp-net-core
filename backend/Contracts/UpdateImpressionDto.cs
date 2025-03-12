using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record UpdateImpressionDto(
        [Required] string Text,
        [Required] List<Guid> Emotions
    );
}
