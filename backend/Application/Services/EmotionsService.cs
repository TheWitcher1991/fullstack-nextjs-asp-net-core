using AutoMapper;
using backend.Communication.Contracts;
using backend.Domain.Abstractions;

namespace backend.Application.Services
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
            return emotions.Select(e => new EmotionDto(
                e.Id,
                e.Label,
                e.Name,
                e.Unicode)).ToList();
        }

        public async Task<EmotionDto> GetEmotion(Guid id)
        {
            var emotion = await repository.GetById(id);
            return _mapper.Map<EmotionDto>(emotion);
        }
    }
}
