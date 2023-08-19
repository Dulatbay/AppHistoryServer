using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Services.BaseInterfaces
{
    public interface IDeletorService<T> where T : class, IDtoModel
    {
        public Task<T> DeleteAsync(int id);
    }
}
