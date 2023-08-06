using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Quiz> GetAll() => _context.Quizzes;

        public async Task<Quiz?> GetByIdAsync(int id) => await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Quiz> DeleteAsync(Quiz model)
        {
            var result = _context.Quizzes.Remove(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Quiz> SaveAsync(Quiz model)
        {
            await _context.Quizzes.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Quiz> UpdateAsync(Quiz model)
        {
            var updated = _context.Quizzes.Update(model);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
