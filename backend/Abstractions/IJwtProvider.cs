using backend.Models;

namespace backend.Toolkit
{
    public interface IJwtProvider
    {
        Guid Decode(string token);
        string Sign(User user);
    }
}