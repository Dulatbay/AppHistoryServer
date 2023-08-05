using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IGetterService<T> : IService<T> where T : class, IModelId
    {
        public IEnumerable<T> GetAll();
        public Task<T?> GetByIdAsync(int id);
    }
}
