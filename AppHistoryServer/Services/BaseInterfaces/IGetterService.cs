using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IGetterService<T, V> : IService<T> where T : class, IModelId where V : class, IDtoModel
    {
        public IEnumerable<V> GetAll();
        public Task<V?> GetByIdAsync(int id);
    }
}
