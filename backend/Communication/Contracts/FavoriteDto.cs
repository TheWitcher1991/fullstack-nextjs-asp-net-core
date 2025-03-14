namespace backend.Communication.Contracts
{
    public record FavoriteDto(
        Guid Id,
        FavoriteBookDto book,
        DateTime CreatedAt
    );
}
