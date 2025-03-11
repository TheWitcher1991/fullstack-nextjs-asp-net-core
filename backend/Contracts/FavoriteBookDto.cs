namespace backend.Contracts
{
    public record FavoriteBookDto(
        Guid Id,
        string ImagePath,
        string FilePath,
        string Title,
        string Description,
        string Publisher,
        string? Holder,
        string? Translator,
        int Age,
        int Pages,
        List<CategoryDto> categories,
        DateTime CreatedAt
    );
}
