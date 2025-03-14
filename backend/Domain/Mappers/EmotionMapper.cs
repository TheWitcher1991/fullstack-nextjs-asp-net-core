using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Mappers
{
    public static class EmotionMapper
    {
        public static EmotionDto ToEmotionDto(this Emotion e)
        {
            return new EmotionDto(
                e.Id,
                e.Label,
                e.Name,
                e.Unicode
            );
        }

        public static List<EmotionDto> ToListEmotionDto(this List<Emotion> emotions)
        {
            return emotions.Select(e => e.ToEmotionDto()).ToList();
        }
    }
}
