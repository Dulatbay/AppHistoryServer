using AppHistoryServer.Models;
using AppHistoryServer.Repositories;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;

namespace AppHistoryServer.Services.Impl
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<Module> GetAll() => _moduleRepository.GetAll();

        public async Task<Module?> GetByIdAsync(int id) => await _moduleRepository.GetByIdAsync(id);

    }
}
