using backend.Models;

namespace backend.Contracts
{
    public record BookDto(
        Guid Id,
        string Title,
        string Description,
        decimal Price,
        Topic Topic,
        Category Category,
        User User,
        DateTime CreatedAt
    );
}
