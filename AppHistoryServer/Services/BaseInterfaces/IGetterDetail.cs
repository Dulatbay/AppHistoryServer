using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IGetterDetail<T> where T : class, IDtoModel
    {
        public Task<T?> GetDetailByIdAsync(int modelId);
    }
}
