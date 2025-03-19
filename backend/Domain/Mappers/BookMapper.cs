using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book b, HashSet<Guid> favoriteIds)
        {
            if (b.Author == null) throw new InvalidOperationException("Author cannot be null.");
            var author = b.Author.ToAuthorDto();

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
                b.Categories.ToListCategoryDto(),
                b.User.ToUserBookDto(),
                author,
                b.CreatedAt,
                favoriteIds.Contains(b.Id)
            );
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
                b.Author.ToAuthorDto(),
                b.Categories.ToListCategoryDto(),
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
