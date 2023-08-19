using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.TopicDto
{
    public class TopicDto : IDtoModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Number { get; set; }
        public int ModuleId { get; set; }
        public object? Content { get; set; }
        public TopicDto(Models.Topic? topic)
        {
            if (topic == null) throw new ArgumentNullException(nameof(topic));
            Id = topic.Id;
            Title = topic.Title;
            Content = topic.Content;
            ModuleId = topic.ModuleId;
        }

        public static IEnumerable<TopicDto> GetAll(IEnumerable<Models.Topic>? topics)
        {
            if (topics == null)
                yield break;

            foreach (var topic in topics)
            {
                yield return new TopicDto(topic);
            }
        }
    }
}
