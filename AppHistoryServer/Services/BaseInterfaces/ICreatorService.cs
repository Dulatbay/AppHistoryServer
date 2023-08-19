using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    // T - Model
    // V - Dto
    public interface ICreatorService<T, V>  where T : class, IDtoModel where V : class, IDtoModel
    {
        public Task<T> CreateAsync(V model);
    }
}
