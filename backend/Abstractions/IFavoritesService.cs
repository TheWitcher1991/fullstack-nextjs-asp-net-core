using backend.Contracts;

namespace backend.Abstractions
{
    public interface IFavoritesService
    {
        Task<Guid> AddFavorite(string token, CreateFavoriteDto dto);
        Task<Guid> DeleteFavorite(Guid id);
        Task<List<FavoriteDto>> GetAllFavorites(string token);
    }
}