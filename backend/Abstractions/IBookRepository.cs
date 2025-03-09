using backend.Models;

namespace backend.Abstractions
{
    public interface IBookRepository
    {
        Task<int> Create(Book book);
        Task<int> Delete(int id);
        Task<List<Book>> Get();
        Task<int> Update(int id, string title, string description, decimal price, Category category, User user);
    }
}