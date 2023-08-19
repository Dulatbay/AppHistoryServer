using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface ITopicRepository : IGetterRepository<Topic>
    {
        Task<Topic?> GetByModuleAndTopicAsync(int moduleId, int topicId);
        ICollection<Topic> GetTopicsByModuleId(int moduleId);
    }
}
