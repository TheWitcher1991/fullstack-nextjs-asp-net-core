using backend.Models;

namespace backend.Abstractions
{
    public interface IFavoriteRepository
    {
        Task<Guid> Add(Favorite favorite);
        Task<Guid> Delete(Guid id);
        Task<List<Favorite>> List();
        Task<List<Favorite>> ListByUserId(Guid userId);
    }
}