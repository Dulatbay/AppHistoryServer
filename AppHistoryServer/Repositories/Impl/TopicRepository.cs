using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Topic> GetAll() => _context.Topics;
        public async Task<Topic?> GetByIdAsync(int id) => await _context.Topics.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Topic?> GetByModuleAndTopicAsync(int moduleId, int topicId) => await _context.Topics.FirstOrDefaultAsync(x => x.ModuleId == moduleId && x.Id == topicId);

        public ICollection<Topic> GetTopicsByModuleId(int moduleId) =>  _context.Topics.Where(x=>x.ModuleId == moduleId).ToList();
    }
}
