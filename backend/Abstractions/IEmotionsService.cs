using backend.Contracts;

namespace backend.Abstractions
{
    public interface IEmotionsService
    {
        Task<EmotionDto> GetEmotion(Guid id);
        Task<List<EmotionDto>> GetEmotions();
    }
}