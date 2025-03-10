using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public interface IUsersService
    {
        Task<UserDto> GetProfile(string token);
        Task<string> Login(string email, string password);
        Task Register(CreateUserDto dto);
        Task<Guid> UpdateProfile(string token, UpdateUserDto dto);
    }
}