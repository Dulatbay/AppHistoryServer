using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Repositories.BaseInterfaces
{
    public interface IGetterRepository<T> : IRepository<T> where T : class, IModelId
    {
        public IEnumerable<T> GetAll();
        public Task<T?> GetByIdAsync(int id);
    }
}
