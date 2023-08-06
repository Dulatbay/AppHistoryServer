using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IUpdaterService<T, V> : IService<T> where T : class, IModelId where V : class, IDtoModel
    {
        public Task<T> UpdateAsync(int id, V model);
    }
}
