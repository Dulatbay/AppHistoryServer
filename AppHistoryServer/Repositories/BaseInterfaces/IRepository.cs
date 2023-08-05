using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Repositories.BaseInterfaces
{
    public interface IRepository<T> where T : class, IModelId
    {
    }
}
