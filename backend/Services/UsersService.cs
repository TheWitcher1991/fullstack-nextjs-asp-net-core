using backend.Abstractions;
using backend.Contracts;
using backend.Models;

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
                hashedPassword);

            await repository.Create(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await repository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.Password);

            if (result)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Sign(user);

            return token;
        }

        public async Task<User> Profile(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
