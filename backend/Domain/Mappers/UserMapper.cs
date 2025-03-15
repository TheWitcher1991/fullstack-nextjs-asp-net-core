using backend.Communication.Contracts;
using backend.Domain.Entities;
using backend.Domain.Models;
using backend.Shared.Enums;

namespace backend.Domain.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserEntity u)
        {
            return User.Create(
                u.Id,
                u.Email,
                u.Phone,
                u.FirstName,
                u.LastName,
                u.Password,
                Role.User
            );
        }

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
