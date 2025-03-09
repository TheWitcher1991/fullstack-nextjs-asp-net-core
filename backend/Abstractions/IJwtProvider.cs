using backend.Models;

namespace backend.Abstractions
{
    public interface IJwtProvider
    {
        string Sign(User user);
    }
}