using backend.Contracts;
using backend.Models;

namespace backend.Mappers
{
    public static class FavoriteMapper
    {
        public static FavoriteDto ToFavoriteDto(this Favorite f)
        {
            return new FavoriteDto(
                f.Id,
                BookMapper.ToFavoriteBookDto(f.Book),
                f.CreatedAt
            );
        }

        public static List<FavoriteDto> ToListBookDto(this List<Favorite> favorites)
        {
            return favorites.Select(f => f.ToFavoriteDto()).ToList();
        }
    }
}
