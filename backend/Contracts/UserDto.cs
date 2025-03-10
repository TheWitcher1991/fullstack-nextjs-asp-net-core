namespace backend.Contracts
{
    public record UserDto(
         Guid Id,
         string Email,
         string Phone,
         string FirstName,
         string LastName,
         DateTime CreatedAt
     );
}
