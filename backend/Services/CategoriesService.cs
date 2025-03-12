using AutoMapper;
using backend.Abstractions;
using backend.Contracts;
using backend.Models;

namespace backend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository repository;
        private readonly ITopicRepository _topicResository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoryRepository categoryRepository, ITopicRepository topicResository, IMapper mapper)
        {

            repository = categoryRepository;
            _topicResository = topicResository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await repository.List();
            return categories.Select(c => new CategoryDto(c.Id, c.Title)).ToList();
        }

        public async Task<CategoryDto> GetCategory(Guid id)
        {
            var category = await repository.GetById(id);

            return _mapper.Map<CategoryDto>(category);
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
