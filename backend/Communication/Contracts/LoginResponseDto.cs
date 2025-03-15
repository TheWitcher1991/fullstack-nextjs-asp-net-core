namespace backend.Communication.Contracts
{
    public record LoginResponseDto(
        string token,
        UserDto account
    );
}
