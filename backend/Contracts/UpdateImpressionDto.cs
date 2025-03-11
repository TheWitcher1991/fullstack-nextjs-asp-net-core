using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record UpdateImpressionDto(
        [Required] string Text,
        [Required] bool IsAdvise,
        [Required] bool IsNoAsdvise,
        [Required] bool IsToTearss,
        [Required] bool IsNice,
        [Required] bool IsBoring,
        [Required] bool IsScary,
        [Required] bool IsWisely,
        [Required] bool IsUnclear
    );
}
