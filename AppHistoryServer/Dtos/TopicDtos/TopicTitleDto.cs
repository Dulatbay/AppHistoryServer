using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.TopicDtos
{
    public class TopicTitleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public TopicTitleDto(Topic topic) 
        {
            Id = topic.Id;
            Title = topic.Title;
        }

        public static IEnumerable<TopicTitleDto> GetAll(IEnumerable<Topic>? topics)
        {
            if (topics == null)
                yield break;

            foreach (var topic in topics)
            {
                yield return new TopicTitleDto(topic);
            }
        }
    }
}
