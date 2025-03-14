using backend.Contracts;
using backend.Models;

namespace backend.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category c)
        {
            return new CategoryDto(
                c.Id,
                c.Title
            );
        }

        public static List<CategoryDto> ToListCategoryDto(this List<Category> categories)
        {
            return categories.Select(c => c.ToCategoryDto()).ToList();
        }
    }
}
