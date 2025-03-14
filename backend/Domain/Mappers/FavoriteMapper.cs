using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Mappers
{
    public static class FavoriteMapper
    {
        public static FavoriteDto ToFavoriteDto(this Favorite f)
        {
            return new FavoriteDto(
                f.Id,
                f.Book.ToFavoriteBookDto(),
                f.CreatedAt
            );
        }

        public static List<FavoriteDto> ToListBookDto(this List<Favorite> favorites)
        {
            return favorites.Select(f => f.ToFavoriteDto()).ToList();
        }
    }
}
