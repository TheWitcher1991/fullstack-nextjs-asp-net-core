using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateTopicDto(
        [Required] string Title
    );
}
