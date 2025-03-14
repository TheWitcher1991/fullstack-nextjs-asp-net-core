using backend.Contracts;
using backend.Models;

namespace backend.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User u)
        {
            return new UserDto(
                    u.Id,
                    u.Email,
                    u.Phone,
                    u.FirstName,
                    u.LastName,
                    u.CreatedAt
            );
        }

        public static UserBookDto ToUserBookDto(this User u)
        {
            return new UserBookDto(
                u.Id,
                u.FirstName,
                u.LastName
            );
        }
    }
}
