using AppHistoryServer.Dtos.ContentDtos.ContainerEnums;
using AppHistoryServer.Utils;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Container : Node
    {

        [JsonProperty("child")]
        public Node? Child { get; set; }

        
        [JsonProperty("outlinedType")]
        public string OutlinedTypeStr
        {
            get { return OutlinedType.ToString(); }
            private set { OutlinedType = value.ParseEnum<OutlinedType>(); }
        }
        [JsonIgnore]
        public OutlinedType OutlinedType { get; set; } = OutlinedType.SOLID;

        
        [JsonProperty("borderColor")]
        public string BorderColorStr
        {
            get { return BorderColor.ToString(); }
            private set { BorderColor = value.ParseEnum<BorderColor>(); }
        }
        [JsonIgnore]
        public BorderColor BorderColor { get; set; } = BorderColor.DEFAULT;

        
        [JsonProperty("backgroundColor")]
        public string BackgroundColorStr
        {
            get { return BackgroundColor.ToString(); }
            private set { BackgroundColor = value.ParseEnum<BackgroundColor>(); }
        }
        [JsonIgnore]
        public BackgroundColor BackgroundColor { get; set; } = BackgroundColor.NONE;
        
        
        [JsonProperty("isLow")]
        public bool IsLow { get; set; } = false;
    }
}
