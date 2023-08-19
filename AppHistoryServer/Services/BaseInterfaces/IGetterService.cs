using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IGetterService<V> where V : class, IDtoModel
    {
        public IEnumerable<V> GetAll();
        public Task<V?> GetByIdAsync(int id);
    }
}
