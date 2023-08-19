using AppHistoryServer.Dtos.ContentDtos.ContainerEnums;
using AppHistoryServer.Dtos.ContentDtos.ImageEnums;
using AppHistoryServer.Utils;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Image : Node
    {
        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }
        
        
        [JsonProperty("title")]
        public string? Title { get; set; }


        [JsonProperty("size")]
        public string SizeStr
        {
            get { return Size.ToString(); }
            private set { Size = value.ParseEnum<Size>(); }
        }
        [JsonIgnore]
        public Size Size { get; set; }
    }
}
