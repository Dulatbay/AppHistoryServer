using AppHistoryServer.Dtos.ContentDtos.IconEnums;
using AppHistoryServer.Utils;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class IconNode : Node
    {
        [JsonProperty("iconName")]
        public string IconStr
        {
            get { return Icon.ToString(); }
            private set { Icon = value.ParseEnum<Icon>(); }
        }
        [JsonIgnore]
        public required Icon Icon { get; set; }
        [JsonProperty("node")]
        public required Node Node { get; set; }
        
        [JsonProperty("gap")]
        public required float Gap { get; set; }

        [JsonProperty("iconColor")]
        public string IconColorStr
        {
            get { return IconColor.ToString(); }
            private set { IconColor = value.ParseEnum<IconColor>(); }
        }
        [JsonIgnore]
        public IconColor IconColor { get; set; } = IconColor.DEFAULT;
    }
}
