using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateCategoryDto(
        [Required] string Title
    );
}
