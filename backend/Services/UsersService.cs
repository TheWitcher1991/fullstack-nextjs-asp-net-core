using backend.Abstractions;
using backend.Contracts;
using backend.Enums;
using backend.Models;
using backend.Repositories;
using backend.Toolkit;

namespace backend.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository repository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            repository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(CreateUserDto dto)
        {
            var hashedPassword = _passwordHasher.Generate(dto.Password);

            var user = User.Create(
                Guid.NewGuid(),
                dto.Email,
                dto.Phone,
                dto.FirstName,
                dto.LastName,
                hashedPassword,
                Role.User);

            await repository.Create(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await repository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.Password);

            if (result)
                throw new BadHttpRequestException("Failed to login");

            var token = _jwtProvider.Sign(user);

            return token;
        }

        private async Task<User> DecodeUserToken(string token)
        {
            var userId = _jwtProvider.Decode(token);

            if (userId == Guid.Empty)
            {
                throw new BadHttpRequestException("Invalid token");
            }

            var user = await repository.GetById(userId);

            return user;
        }

        public async Task<Guid> UpdateProfile(string token, UpdateUserDto dto)
        {
            var user = await this.DecodeUserToken(token);

            return await repository.Update(user.Id, dto);
        }

        public async Task<UserDto> GetProfile(string token)
        {
            var user = await this.DecodeUserToken(token);

            var userDto = new UserDto(
                user.Id,
                user.Email,
                user.Phone,
                user.FirstName,
                user.LastName,
                user.CreatedAt);

            return userDto;
        }
    }
}
