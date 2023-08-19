using AppHistoryServer.Dtos.QuestionDtos;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Question : Node
    {
        [JsonProperty("question")]
        public QuestionDto QuestionDto { get; set; }
    }
}
