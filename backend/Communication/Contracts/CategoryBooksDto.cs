namespace backend.Communication.Contracts
{
    public record CategoryBooksDto(
        Guid CategoryId,
        string CategoryTitle,
        List<BookDto> Books
    );
}
