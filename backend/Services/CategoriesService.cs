using backend.Abstractions;
using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository repository;
        private readonly ITopicRepository _topicResository;

        public CategoriesService(ICategoryRepository categoryRepository, ITopicRepository topicResository)
        {

            repository = categoryRepository;
            _topicResository = topicResository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await repository.List();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await repository.GetById(id);
        }

        public async Task<Guid> CreateCategory(CreateCategoryDto dto)
        {
            var topic = await _topicResository.GetById(dto.Topic);

            if (topic == null)
                throw new BadHttpRequestException("Bad request");

            var category = Category.Create(
                Guid.NewGuid(),
                dto.Title,
                topic
            );

            return await repository.Create(category);
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
