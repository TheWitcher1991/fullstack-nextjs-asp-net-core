using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public interface IUsersService
    {
        Task<string> Login(string email, string password);
        Task Register(CreateUserDto dto);
        Task<User> Profile(Guid id);
    }
}