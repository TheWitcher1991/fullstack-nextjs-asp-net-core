namespace backend.Contracts
{
    public record ImpressionDto(
        Guid Id,
        string Text,
        BookDto Book,
        UserBookDto User,
        List<EmotionDto> emotions,
        DateTime CreatedAt
    );
}
