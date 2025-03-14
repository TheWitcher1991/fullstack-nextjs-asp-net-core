using backend.Communication.Contracts;
using backend.Domain.Models;

namespace backend.Domain.Mappers
{
    public static class ImpressionMapper
    {
        public static ImpressionDto ToImpressionDto(this Impression i)
        {
            return new ImpressionDto(
                i.Id,
                i.Text,
                i.Book.ToBookDto(new HashSet<Guid>()),
                i.User.ToUserBookDto(),
                i.Emotions.ToListEmotionDto(),
                i.CreatedAt
            );
        }

        public static ImpressionUserDto ToImpressionUserDto(this Impression i)
        {
            return new ImpressionUserDto(
                i.Id,
                i.Text,
                i.Book.ToBookDto(new HashSet<Guid>()),
                i.Emotions.ToListEmotionDto(),
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
