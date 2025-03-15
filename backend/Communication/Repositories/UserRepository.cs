using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain;
using backend.Domain.Abstractions;
using backend.Domain.Entities;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Communication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.Phone,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<Guid> Update(Guid id, UpdateUserDto user)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.Email, b => user.Email)
                    .SetProperty(u => u.Phone, b => user.Phone)
                    .SetProperty(u => u.FirstName, b => user.FirstName)
                    .SetProperty(u => u.LastName, b => user.LastName));

            return id;
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> GetById(Guid id)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }
    }
}
