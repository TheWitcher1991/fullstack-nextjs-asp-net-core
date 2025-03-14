namespace backend.Communication.Contracts
{
    public record BookDto(
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
        UserBookDto User,
        DateTime CreatedAt,
        bool IsFavorite
    );
}