using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Abstractions;
using backend.Domain.Mappers;
using backend.Domain.Models;

namespace backend.Application.Services
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
            return categories.Select(c => CategoryMapper.ToCategoryDto(c)).ToList();
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
