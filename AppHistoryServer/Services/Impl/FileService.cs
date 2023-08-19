using AppHistoryServer.Services.Interfaces;
using System.Linq;

namespace AppHistoryServer.Services.Impl
{
    public class FileService : IFileService
    {
        public async Task<string> ChangeFileAsync(IFormFile file, string? oldPath)
        {
            if (file == null || file.Length == 0)
            {
                throw new BadHttpRequestException("Пустой файл");
            }

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".jfif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new BadHttpRequestException("Неправильный формат файла");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var newFilePath = Path.Combine("Static", uniqueFileName);

            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (!string.IsNullOrEmpty(oldPath) && File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }

            return newFilePath;
        }

        public async Task<string> CreateFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new BadHttpRequestException("Пустой файл");
            }

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".jfif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new BadHttpRequestException("Неправильный формат файла");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine("Static", uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
