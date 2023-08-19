using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IUpdaterService<T, V>  where T : class, IDtoModel where V : class, IDtoModel
    {
        public Task<T> UpdateAsync(int id, V model);
    }
}
