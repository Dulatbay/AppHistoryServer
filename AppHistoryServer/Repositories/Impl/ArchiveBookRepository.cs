using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Repositories.Impl
{
    public class ArchiveBookRepository : IArchiveBookRepository
    {
        private readonly ApplicationDbContext _context;

        public ArchiveBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ArchiveBook> GetAll() => _context.ArchiveBooks;

        public async Task<ArchiveBook?> GetByIdAsync(int id) => await _context.ArchiveBooks.FirstOrDefaultAsync(x => x.Id == id);
    }
}
