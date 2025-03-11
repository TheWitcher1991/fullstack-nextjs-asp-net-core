namespace backend.Contracts
{
    public record FilterBookDto(
        string ?Search,
        string ?Ordering,
        Guid ?Category,
        Guid ?User,
        int Page = 1,
        int PageSize = 15
    );
}
