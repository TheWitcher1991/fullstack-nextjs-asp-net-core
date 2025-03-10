namespace backend.Contracts
{
    public record FavoriteDto(
        Guid Id,
        FavoriteBookDto book,
        DateTime CreatedAt
    );
}
