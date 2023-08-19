using System.Linq;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IFileService
    {
        public Task<string> CreateFileAsync(IFormFile file);
        public Task<string> ChangeFileAsync(IFormFile file, string? filePath);
    }
}
