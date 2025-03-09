namespace backend.Contracts
{
    public record FilterBookDto(
        string ?search,
        string ?ordering,
        Guid ?category,
        decimal ?minPrice,
        decimal ?maxPrice,
        int page = 1,
        int pageSize = 15
    );
}
