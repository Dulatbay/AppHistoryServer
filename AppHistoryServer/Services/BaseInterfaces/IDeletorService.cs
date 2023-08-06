using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IDeletorService<T> : IService<T> where T : class, IModelId
    {
        public Task<T> DeleteAsync(int id);
    }
}
