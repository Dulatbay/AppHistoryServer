using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IUserService : IGetterService<User>
    {
        public Task<User?> GetUserByEmail(string email);
    }
}
