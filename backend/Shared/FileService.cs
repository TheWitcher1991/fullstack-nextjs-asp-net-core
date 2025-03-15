using backend.Domain.Abstractions;

namespace backend.Shared
{
    public class FileService : IFileService
    {
        private readonly string _rootPath;

        public FileService()
        {
            _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var folder = Config.MEDIA_FOLDER_NAME;

            var uploadsFolder = Path.Combine(_rootPath, folder);
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{folder}/{fileName}";
        }
    }
}
