using backend.Abstractions;
using backend.Models;

namespace backend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository repository;

        public CategoriesService(ICategoryRepository categoryRepository)
        {

            repository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await repository.List();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<Guid> CreateCategory(string title)
        {
            var category = Category.Create(
                Guid.NewGuid(),
                title
            );

            return await repository.Create(category);
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
