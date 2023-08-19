using AppHistoryServer.Dtos.ModuleDtos;
using AppHistoryServer.Dtos.TopicDto;
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
        public ICollection<ModuleTopicsTitleDto> GetAllModuleTopicsTitle()
        {
            var modules = _moduleRepository.GetAll();
            return ModuleTopicsTitleDto.GetAll(modules).ToList();
        }

        public IEnumerable<ModuleDto> GetAll() => ModuleDto.GetAll(_moduleRepository.GetAll());

        public async Task<ModuleDto?> GetByIdAsync(int id) => new ModuleDto(await _moduleRepository.GetByIdAsync(id));
       
    }
}
