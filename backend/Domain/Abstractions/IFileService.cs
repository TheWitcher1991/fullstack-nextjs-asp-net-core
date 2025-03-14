namespace backend.Domain.Abstractions
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}