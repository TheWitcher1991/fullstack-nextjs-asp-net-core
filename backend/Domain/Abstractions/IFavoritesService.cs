using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface IFavoritesService
    {
        Task<Guid> AddFavorite(string token, CreateFavoriteDto dto);
        Task<Guid> DeleteFavorite(Guid id);
        Task<List<FavoriteDto>> GetAllFavorites(string token);
    }
}