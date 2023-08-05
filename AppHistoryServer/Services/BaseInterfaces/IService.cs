using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IService<T> where T : class, IModelId
    {
    }
}
