namespace backend.Contracts
{
    public record UpdateUserDto(
         string Email,
         string Phone,
         string FirstName,
         string LastName
     );
}
