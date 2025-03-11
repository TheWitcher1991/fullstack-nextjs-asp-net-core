using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record ImpressionDto(
        Guid Id,
        string Text,
        bool IsAdvise,
        bool IsNoAsdvise,
        bool IsToTearss,
        bool IsNice,
        bool IsBoring,
        bool IsScary,
        bool IsWisely,
        bool IsUnclear,
        UserBookDto User,
        DateTime CreatedAt
    );
}
