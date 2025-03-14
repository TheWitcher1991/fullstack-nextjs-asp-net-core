using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
{
    public record UpdateImpressionDto(
        [Required] string Text,
        [Required] List<Guid> Emotions
    );
}
