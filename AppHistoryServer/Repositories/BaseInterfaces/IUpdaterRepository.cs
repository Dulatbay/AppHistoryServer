using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Repositories.BaseInterfaces
{
    public interface IUpdaterRepository<T> : IRepository<T> where T : class, IModelId
    {
        public Task<T> UpdateAsync(T model);
    }
}
