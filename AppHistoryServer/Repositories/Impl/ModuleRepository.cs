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

        public IEnumerable<Module> GetAll() => _context.Modules;

        public async Task<Module?> GetByIdAsync(int id) => await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<Module> SaveAsync(Module module) {
            await _context.Modules.AddRangeAsync(module);
            await _context.SaveChangesAsync();
            return module;
        }
    }
}
