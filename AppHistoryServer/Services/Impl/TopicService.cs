using AppHistoryServer.Dtos.ModuleDtos;
using AppHistoryServer.Dtos.TopicDto;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;

namespace AppHistoryServer.Services.Impl
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IModuleRepository _moduleRepository;

        public TopicService(ITopicRepository topicRepository, IModuleRepository moduleRepository)
        {
            _topicRepository = topicRepository;
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<TopicDto> GetAll()
        {
            return TopicDto.GetAll(_topicRepository.GetAll());
        }

     

        public async Task<TopicDto?> GetByIdAsync(int id)
        {
            var result = await _topicRepository.GetByIdAsync(id);
            if (result == null) return null;
            return new TopicDto(result);
        }

        public async Task<TopicDto> GetByModuleIdAndTopicIdAsync(int moduleId, int topicId)
        {
            var topic = await _topicRepository.GetByModuleAndTopicAsync(moduleId, topicId);
            if (topic == null) throw new BadHttpRequestException("Тема не найдена");

            return new TopicDto(topic);
        }

        public async Task<ModuleWithTopics> GetTopicsByModuleIdAsync(int moduleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null)
                throw new BadHttpRequestException("Модуль не найден");

            return new ModuleWithTopics(module, _topicRepository.GetTopicsByModuleId(moduleId).ToList());
        }
    }
}
