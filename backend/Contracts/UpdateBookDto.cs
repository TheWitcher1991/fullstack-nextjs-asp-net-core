namespace backend.Contracts
{
    public record UpdateBookDto(
        string ?title,
        string? description,
        decimal? price
    );
}
