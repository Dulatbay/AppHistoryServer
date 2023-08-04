using AppHistoryServer.Models;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public Task<User?> GetUserById(int id);
        public Task<User?> GetUserByEmail(string email);
    }
}
