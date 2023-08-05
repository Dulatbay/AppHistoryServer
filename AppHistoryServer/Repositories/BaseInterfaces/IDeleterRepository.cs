using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Repositories.BaseInterfaces
{
    public interface IDeleterRepository<T> : IRepository<T> where T : class, IModelId
    {
        public Task<T> DeleteAsync(T model);
    }
}
