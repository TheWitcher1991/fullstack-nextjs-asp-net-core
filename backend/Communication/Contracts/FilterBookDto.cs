namespace backend.Communication.Contracts
{
    public record FilterBookDto(
        string? Search,
        string? Ordering,
        Guid? Category,
        Guid? User,
        Guid? Author,
        int Page,
        int PageSize
    );
}
