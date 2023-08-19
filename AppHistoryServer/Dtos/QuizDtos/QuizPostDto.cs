using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizPostDto : IDtoModel
    {
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("questions")]
        public ICollection<Question>? Questions { get; set; }
        [JsonProperty("isVerified")]
        public bool? IsVerified { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
