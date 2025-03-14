namespace backend.Communication.Contracts
{
    public record ImpressionUserDto(
        Guid Id,
        string Text,
        BookDto book,
        List<EmotionDto> emotions,
        DateTime CreatedAt
    );
}
