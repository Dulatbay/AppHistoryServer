using AppHistoryServer.Models;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User?> GetUserByUserNameAsync(string userName);
        public Task<User?> GetUserByEmailAsync(string email);
        public IEnumerable<User> GetAllUsersAsync();
        public Task<User> Save(User user);
    }
}
