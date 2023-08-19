using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Term : Node
    {
        [JsonProperty("termText")]
        public required string TermText { get; set; } = null!;

        [JsonProperty("description")]
        public required string Description { get; set; } = null!;

        [JsonProperty("isWithHyphen")]
        public required bool IsWithHyphen { get; set; } = false;


    }
}
