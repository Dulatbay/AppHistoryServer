using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    // T - Model
    // V - Dto
    public interface ICreatorService<T, V> : IService<T> where T : class, IModelId where V : class, IDtoModel
    {
        public Task<T> CreateAsync(V model);
    }
}
