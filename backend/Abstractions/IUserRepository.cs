using backend.Models;

namespace backend.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> Create(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
    }
}