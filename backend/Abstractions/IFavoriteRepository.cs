using backend.Models;

namespace backend.Abstractions
{
    public interface IFavoriteRepository
    {
        Task<Guid> Add(Favorite favorite);
        Task<Guid> Delete(Guid id);
        Task<List<Favorite>> List();
        Task<HashSet<Guid>> ListIdByUserId(Guid ?userId);
        Task<List<Favorite>> ListByUserId(Guid userId);
    }
}