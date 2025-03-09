using backend.Contracts;

namespace backend.Services
{
    public interface IUsersService
    {
        Task<string> Login(string email, string password);
        Task Register(CreateUserDto dto);
    }
}