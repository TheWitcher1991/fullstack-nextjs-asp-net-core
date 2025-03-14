using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
{
    public record CreateTopicDto(
        [Required] string Title
    );
}
