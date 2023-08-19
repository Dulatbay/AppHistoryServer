using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;

namespace AppHistoryServer.Repositories.Impl
{
    public class PassedUserQuizzesRepository : IPassedUserQuizzesRepository
    {
        private readonly ApplicationDbContext _context;
        
        public PassedUserQuizzesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<PassedUserQuizzes> SaveAsync(PassedUserQuizzes model)
        {
            await _context.PassedUserQuizzes.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
