using backend.Contracts;
using backend.Models;

namespace backend.Mappers
{
    public static class ImpressionMapper
    {
        public static ImpressionDto ToImpressionDto(this Impression i)
        {
            return new ImpressionDto(
                i.Id,
                i.Text,
                BookMapper.ToBookDto(i.Book, new HashSet<Guid>()),
                UserMapper.ToUserBookDto(i.User),
                EmotionMapper.ToListEmotionDto(i.Emotions),
                i.CreatedAt
            );
        }

        public static ImpressionUserDto ToImpressionUserDto(this Impression i)
        {
            return new ImpressionUserDto(
                i.Id,
                i.Text,
                BookMapper.ToBookDto(i.Book, new HashSet<Guid>()),
                EmotionMapper.ToListEmotionDto(i.Emotions),
                i.CreatedAt
            );
        }

        public static List<ImpressionDto> ToListImpressionDto(this List<Impression> impressions)
        {
            return impressions.Select(i => i.ToImpressionDto()).ToList();
        }

        public static List<ImpressionUserDto> ToListImpressionUserDto(this List<Impression> impressions)
        {
            return impressions.Select(i => i.ToImpressionUserDto()).ToList();
        }
    }
}
