namespace backend.Communication.Contracts
{
    public record AuthorDto(
         Guid Id,
         string FullName,
         string About,
         string AvatarPath,
         DateTime CreatedAt
     );
}
