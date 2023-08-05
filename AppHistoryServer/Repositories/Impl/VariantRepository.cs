using AppHistoryServer.Models.Variant;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class VariantRepository : IVariantRepository
    {
        private readonly ApplicationDbContext _context;

        public VariantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Variant> GetAll() => _context.Variants;

        public async Task<Variant?> GetByIdAsync(int id) => await _context.Variants.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Variant> SaveAsync(Variant model)
        {
            await _context.Variants.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Variant> UpdateAsync(Variant model)
        {
            var updated = _context.Variants.Update(model);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
