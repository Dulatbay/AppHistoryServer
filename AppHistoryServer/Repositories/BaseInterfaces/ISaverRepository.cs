using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Repositories.BaseInterfaces
{
    public interface ISaverRepository<T> : IRepository<T> where T : class, IModelId
    {
        public Task<T> SaveAsync(T model);
    }
}
