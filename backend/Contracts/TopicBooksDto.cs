namespace backend.Contracts
{
    public record TopicBooksDto(
        Guid TopicId,
        string TopicTitle,
        List<BookDto> Books
    );
}
