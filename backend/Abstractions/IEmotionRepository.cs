using backend.Models;

namespace backend.Abstractions
{
    public interface IEmotionRepository
    {
        Task<Guid> Create(Emotion emotion);
        Task<Guid> Delete(Guid id);
        Task<Emotion> GetById(Guid id);
        Task<List<Emotion>> GetByIds(List<Guid> ids);
        Task<List<Emotion>> GetByNames(List<string> names);
        Task<List<Emotion>> List();
    }
}