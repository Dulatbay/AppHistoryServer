using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public abstract class Node
    {
        [JsonProperty("componentName")]
        public string ComponentName { get; set; }
        [JsonProperty("padding")]
        public string Padding { get; set; } = "0";
        [JsonProperty("margin")]
        public string Margin { get; set; } = "0";
        
        [JsonProperty("width")]
        public string Width { get; set; } = "100%";

        [JsonProperty("height")]
        public string Height { get; set; } = "100%";


        public Node()
        {
            ComponentName = GetType().Name;
        }
    }
}
