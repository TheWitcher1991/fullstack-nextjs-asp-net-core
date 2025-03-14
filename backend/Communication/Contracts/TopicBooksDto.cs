namespace backend.Communication.Contracts
{
    public record TopicBooksDto(
        Guid TopicId,
        string TopicTitle,
        List<BookDto> Books
    );
}
