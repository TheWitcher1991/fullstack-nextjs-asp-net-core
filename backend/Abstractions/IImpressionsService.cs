using backend.Contracts;

namespace backend.Services
{
    public interface IImpressionsService
    {
        Task<Guid> CreateImpression(CreateImpressionDto dto);
        Task<Guid> DeleteImpression(Guid id);
        Task<ImpressionDto> GetImpression(Guid id);
        Task<List<ImpressionDto>> GetImpressionsByBookId(Guid bookId);
        Task<List<ImpressionDto>> GetImpressionsByUserId(Guid userId);
        Task<Guid> UpdateImpression(Guid id, UpdateImpressionDto impression);
    }
}