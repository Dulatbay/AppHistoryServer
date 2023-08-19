using AppHistoryServer.Dtos.ContentDtos.ContentViewerEnums;
using AppHistoryServer.Utils;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class ContentViewer : Node
    {
        [JsonProperty("text")]
        public required Text Title { get; set; } = null!;
        
        [JsonProperty("gap")]
        public float Gap { get; set; } = 2;
        
        [JsonProperty("child")]
        public Node? Child { get; set; }

        
        [JsonProperty("titleBottomBorder")]
        public string TitleBottomBorderStr
        {
            get { return TitleBottomBorder.ToString(); }
            private set { TitleBottomBorder = value.ParseEnum<TitleBottomBorder>(); }
        }
        [JsonIgnore]
        public TitleBottomBorder TitleBottomBorder { get; set; } = TitleBottomBorder.NONE;

        [JsonProperty("titleBottomColor")]
        public string TitleBottomColor { get; set; } = "#fff";

    }
}
