using AppHistoryServer.Repositories.Interfaces;

namespace AppHistoryServer.Repositories.Impl
{
    public class PassedUserQuestionsRepository : IPassedUserQuestionsRepository
    {
        private readonly ApplicationDbContext _context;

        public PassedUserQuestionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.PassedUserQuestions> SaveAsync(Models.PassedUserQuestions model)
        {
            await _context.PassedUserQuestions.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
