using AutoMapper;
using backend.Abstractions;
using backend.Contracts;

namespace backend.Services
{
    public class EmotionsService : IEmotionsService
    {
        private readonly IEmotionRepository repository;
        private readonly IMapper _mapper;

        public EmotionsService(IEmotionRepository _repository, IMapper mapper)
        {
            repository = _repository;
            _mapper = mapper;
        }

        public async Task<List<EmotionDto>> GetEmotions()
        {
            var emotions = await repository.List();
            return emotions.Select(i => new EmotionDto(
                i.Id,
                i.Label,
                i.Name,
                i.Unicode)).ToList();
        }

        public async Task<EmotionDto> GetEmotion(Guid id)
        {
            var emotion = await repository.GetById(id);
            return _mapper.Map<EmotionDto>(emotion);
        }
    }
}
