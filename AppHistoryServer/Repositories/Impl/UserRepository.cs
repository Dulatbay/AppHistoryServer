using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsersAsync() => _context.Users;

        public async Task<User?> GetUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User?> GetUserByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User?> GetUserByUserNameAsync(string userName) => await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<User> Save(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
