using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> Create(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task<Guid> Update(Guid id, UpdateUserDto book);
    }
}