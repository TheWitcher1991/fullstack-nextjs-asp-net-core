namespace backend.Contracts
{
    public record FilterBookDto(
        string ?Search,
        string ?Ordering,
        Guid ?Category,
        Guid ?Topic,
        decimal ?MinPrice,
        decimal ?MaxPrice,
        int Page = 1,
        int PageSize = 15
    );
}
