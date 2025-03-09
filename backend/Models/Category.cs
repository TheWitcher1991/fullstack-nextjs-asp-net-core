using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Category
    {
        private Category(string title)
        {
            Title = title;
        }
 
        public int Id { get; }
        public string Title { get; } = string.Empty;
        public List<Book> Books { get; } = new();

        public static (Category Category, string Error) Create(string title)
        {
            var error = string.Empty;

            var category = new Category(title);

            return (category, error);
        }
    }
}
