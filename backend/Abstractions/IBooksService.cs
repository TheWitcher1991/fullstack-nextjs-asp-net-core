using backend.Models;

namespace backend.Abstractions
{
    public interface IBooksService
    {
        Task<int> CreateBook(Book book);
        Task<int> DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<int> UpdateBook(int id, string title, string description, decimal price, Category category, User user);
    }
}