using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;

namespace AppHistoryServer.Services.Impl
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public IEnumerable<Topic> GetAll()
        {
            return _topicRepository.GetAll();
        }

        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _topicRepository.GetByIdAsync(id);
        }
    }
}
