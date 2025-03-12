namespace backend.Contracts
{
    public record EmotionDto(
        Guid Id,
        string Label,
        string Name,
        string Unicode
    );
}
