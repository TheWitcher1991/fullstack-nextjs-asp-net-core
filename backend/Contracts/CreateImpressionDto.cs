using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateImpressionDto(
        [Required] string Text,
        [Required] List<Guid> Emotions,
        [Required] Guid User,
        [Required] Guid Book
    );
}
