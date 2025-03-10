namespace backend.Contracts
{
    public record UpdateBookDto(
        string Title,
        string Description,
        decimal Price
    );
}
