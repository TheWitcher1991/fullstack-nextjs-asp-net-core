using backend.Contracts;
using backend.Models;

namespace backend.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book b, HashSet<Guid> favoriteIds)
        {
            return new BookDto(
                b.Id,
                b.ImagePath,
                b.FilePath,
                b.Title,
                b.Description,
                b.Publisher,
                b.Holder,
                b.Translator,
                b.Age,
                b.Pages,
                CategoryMapper.ToListCategoryDto(b.Categories),
                UserMapper.ToUserBookDto(b.User),
                b.CreatedAt,
                favoriteIds.Contains(b.Id)
            ) ;
        }

        public static FavoriteBookDto ToFavoriteBookDto(this Book b)
        {
            return new FavoriteBookDto(
                b.Id,
                b.ImagePath,
                b.FilePath,
                b.Title,
                b.Description,
                b.Publisher,
                b.Holder,
                b.Translator,
                b.Age,
                b.Pages,
                CategoryMapper.ToListCategoryDto(b.Categories),
                b.CreatedAt
            );
        }

        public static List<BookDto> ToListBookDto(this List<Book> books, HashSet<Guid> favoriteIds)
        {
            return books.Select(b => b.ToBookDto(favoriteIds)).ToList();
        }

        public static List<FavoriteBookDto> ToListFavoriteBookDto(this List<Book> books)
        {
            return books.Select(b => b.ToFavoriteBookDto()).ToList();
        }
    }
}
