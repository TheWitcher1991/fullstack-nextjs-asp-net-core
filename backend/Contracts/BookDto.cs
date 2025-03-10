using backend.Models;

namespace backend.Contracts
{
    public record BookDto(
        Guid Id,
        string Title,
        string Description,
        decimal Price,
        TopicDto Topic,
        CategoryDto Category,
        UserDto User,
        DateTime CreatedAt
    );
}
