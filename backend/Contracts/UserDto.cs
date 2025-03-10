namespace backend.Contracts
{
    public record UserDto(
         Guid id,
         string Email,
         string Phone,
         string FirstName,
         string LastName,
         DateTime CreatedAt
     );
}
