using AppHistoryServer.Dtos.TopicDtos;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.ModuleDtos
{
    public class ModuleTopicsTitleDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<TopicTitleDto> Topics { get; set; } = new List<TopicTitleDto>();

        public ModuleTopicsTitleDto(Module module, ICollection<TopicTitleDto> topics)
        {
            Id = module.Id;
            Title = module.Title;
            Topics = topics;
        }
        public static IEnumerable<ModuleTopicsTitleDto> GetAll(IEnumerable<Module>? modules)
        {
            if (modules == null)
                yield break;

            foreach (var module in modules)
            {
                yield return new ModuleTopicsTitleDto(module, TopicTitleDto.GetAll(module.Topics).ToList());
            }
        }
    }
}
