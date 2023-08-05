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
    }
}
