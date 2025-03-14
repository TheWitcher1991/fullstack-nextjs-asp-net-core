using backend.Contracts;
using backend.Models;

namespace backend.Mappers
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
