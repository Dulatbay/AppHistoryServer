using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Question> DeleteAsync(Question model)
        {
            var removed = _context.Questions.Remove(model);
            await _context.SaveChangesAsync();
            return removed.Entity;
        }

        public IEnumerable<Question> GetAll() => _context.Questions.Include(q=>q.Variants).Include(q=>q.Topic);

        public async Task<Question?> GetByIdAsync(int id) => await _context.Questions.Include(q => q.Variants).Include(q => q.Topic).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ICollection<Question>> GetQuestionsByTopicIdAsync(int topicId, int level)
        {
            return await _context.Questions.Include(q => q.Variants).Include(q => q.Topic).Where(x => x.Topic.Id == topicId && x.Level == level).ToListAsync();
        }

        public async Task<Question> SaveAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question model)
        {
            var updated = _context.Questions.Update(model);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
