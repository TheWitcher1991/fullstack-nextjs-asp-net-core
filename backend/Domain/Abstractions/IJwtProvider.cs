using backend.Domain.Models;

namespace backend.Domain.Abstractions
{
    public interface IJwtProvider
    {
        Guid Decode(string token);
        string Sign(User user);
    }
}