using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.ModuleDtos
{
    public class ModuleWithTopics
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<TopicDto.TopicDto> Topics { get; set; } = new List<TopicDto.TopicDto>();

        public ModuleWithTopics(Module module, ICollection<Topic> topics)
        {
            Id = module.Id;
            Title = module.Title;
            Topics = TopicDto.TopicDto.GetAll(topics).ToList();
        }
    }
}
