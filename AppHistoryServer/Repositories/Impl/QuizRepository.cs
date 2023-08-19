using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Dtos.UserDtos;
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

        public IEnumerable<Quiz> GetAll()
        {
            var res = _context.Quizzes?.Include(q => q.Questions)
                                       .ThenInclude(x => x.Variants)
                                       .Include(x => x.PassedUserQuizzes)
                                       .ThenInclude(x => x.PassedQuestions)
                                       .Include(x => x.Author)
                                       .ToList();
            return res ?? new List<Quiz>();
        }

        public async Task<Quiz?> GetByIdAsync(int id) => await _context.Quizzes.Include(q => q.Questions)
                                                                               .ThenInclude(x => x.Variants)
                                                                               .Include(x => x.PassedUserQuizzes)
                                                                               .ThenInclude(x => x.PassedQuestions)
                                                                               .Include(x => x.Author)
                                                                               .FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task<ICollection<Quiz>> GetQuizzesByFilterAsync(QuizType type, QuizCategory category, UserDto user)
        {
            var query = _context.Quizzes.Include(q => q.Questions);
            IQueryable<Quiz> queryable = query!;

            switch (type)
            {
                case QuizType.PASSED:
                    queryable = query.Where(q => q.PassedUserQuizzes.Any(puq => puq.User.Id == user.Id));
                    break;
                case QuizType.NOT_PASSED:
                    queryable = query.Where(q => !q.PassedUserQuizzes.Any(puq => puq.User.Id == user.Id));
                    break;
            }



            switch (category)
            {
                case QuizCategory.POPULAR:
                    queryable = queryable.OrderByDescending(q => q.PassedUserQuizzes.Count);
                    break;
                case QuizCategory.NEW:
                    queryable = queryable.OrderByDescending(q => q.CreatedAt);
                    break;
                case QuizCategory.TOP:
                    queryable = queryable.OrderByDescending(q => q.Level);
                    break;
                case QuizCategory.MY:
                    queryable = queryable.Where(q => q.AuthorId == user.Id).OrderBy(x => x.Id);
                    break;
            }

            var result = await queryable.ToListAsync();
            return result;
        }

    }
}
