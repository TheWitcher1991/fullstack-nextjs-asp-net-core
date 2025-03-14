using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface IEmotionsService
    {
        Task<EmotionDto> GetEmotion(Guid id);
        Task<List<EmotionDto>> GetEmotions();
    }
}