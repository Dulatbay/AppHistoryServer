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

        public async Task<User?> GetUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);


        public async Task<User?> GetUserByUserNameAsync(string userName) => await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);

        public async Task<User> SaveAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public IEnumerable<User> GetAll() => _context.Users;

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<User?> GetUserCardAsync(int id)
        {
            return await _context.Users.Include(x => x.PassedUserTopics)
                                .Include(x => x.PassedUserQuestions)
                                .ThenInclude(x=>x.Question)
                                .Include(x=>x.PassedUserQuizzes)
                                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<User> UpdateAsync(User model)
        {
            var updated = _context.Users.Update(model);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
