using backend.Contracts;
using backend.Models;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> Create(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task<Guid> Update(Guid id, UpdateUserDto book);
    }
}