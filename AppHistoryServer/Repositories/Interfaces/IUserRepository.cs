using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IUserRepository : IGetterRepository<User>, ISaverRepository<User>
    {
        public Task<User?> GetUserByUserNameAsync(string userName);
        public Task<User?> GetUserByEmailAsync(string email);
    }
}
