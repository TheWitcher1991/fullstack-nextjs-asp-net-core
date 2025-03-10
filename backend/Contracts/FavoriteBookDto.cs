namespace backend.Contracts
{
    public record FavoriteBookDto(
        Guid Id,
        string ImagePath,
        string FilePath,
        string Title,
        string Description,
        decimal Price,
        TopicDto Topic,
        CategoryDto Category,
        DateTime CreatedAt
    );
}
