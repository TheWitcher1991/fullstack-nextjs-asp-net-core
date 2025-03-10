namespace backend.Abstractions
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}