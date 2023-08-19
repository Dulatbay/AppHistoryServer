using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.ModuleDtos;
using AppHistoryServer.Dtos.TopicDto;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IModuleService : IGetterService<ModuleDto>
    {
        public ICollection<ModuleTopicsTitleDto> GetAllModuleTopicsTitle();
    }
}
