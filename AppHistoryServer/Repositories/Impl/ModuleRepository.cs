using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Module> GetAll() => _context.Modules.Include(x => x.Topics);

        public async Task<Module?> GetByIdAsync(int id) => await _context.Modules.Include(x => x.Topics).FirstOrDefaultAsync(m => m.Id == id);

        public async Task<ICollection<Topic>> GetTopic(int moduleId)
        {
            var result = (await _context.Modules.Include(x => x.Topics).FirstOrDefaultAsync(x => x.Id == moduleId));
            if(result == null) return new List<Topic>();
            return result.Topics;
        }
    }
}

