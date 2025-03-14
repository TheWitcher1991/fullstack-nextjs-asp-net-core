using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
{
    public record CreateCategoryDto(
        [Required] string Title,
        [Required] Guid Topic
    );
}
