using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Mappers
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
