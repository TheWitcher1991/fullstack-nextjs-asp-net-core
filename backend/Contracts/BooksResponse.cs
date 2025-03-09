using backend.Models;

namespace backend.Contracts
{
    public record BooksResponse(
        int Id,
        string Title,
        string Description,
        decimal price,
        Category category,
        User user
    );
}
