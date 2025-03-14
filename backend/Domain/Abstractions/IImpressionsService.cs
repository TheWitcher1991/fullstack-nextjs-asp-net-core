using backend.Communication.Contracts;

namespace backend.Domain.Abstractions
{
    public interface IImpressionsService
    {
        Task<Guid> CreateImpression(CreateImpressionDto dto);
        Task<Guid> DeleteImpression(Guid id);
        Task<ImpressionDto> GetImpression(Guid id);
        Task<List<ImpressionDto>> GetImpressionsByBookId(Guid bookId);
        Task<List<ImpressionUserDto>> GetImpressionsByUserId(Guid userId);
        Task<Guid> UpdateImpression(Guid id, UpdateImpressionDto impression);
    }
}