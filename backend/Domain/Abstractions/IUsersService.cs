using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface IUsersService
    {
        Task<UserDto> GetProfile(string token);
        Task<LoginResponseDto> Login(string email, string password);
        Task Register(CreateUserDto dto);
        Task<Guid> UpdateProfile(string token, UpdateUserDto dto);
    }
}