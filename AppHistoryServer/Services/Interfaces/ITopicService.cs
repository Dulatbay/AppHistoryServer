using AppHistoryServer.Dtos.ModuleDtos;
using AppHistoryServer.Dtos.TopicDto;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface ITopicService : IGetterService<TopicDto>
    {
        public Task<TopicDto> GetByModuleIdAndTopicIdAsync(int moduleId, int topicId);
        public Task<ModuleWithTopics> GetTopicsByModuleIdAsync(int moduleId);
    }
}
