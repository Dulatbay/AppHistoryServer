using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class ListViewer : Node
    {
        [JsonProperty("gap")]
        public float Gap { get; set; }

        [JsonProperty("children")]
        public ICollection<Node> Children { get; set; } = new List<Node>();
        
        [JsonProperty("isVertical")]
        public bool IsVertical { get; set; } = false;
    }
}
