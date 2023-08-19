using AppHistoryServer.Dtos.ContentDtos.TextEnums;
using AppHistoryServer.Utils;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Text : Node
    {

        // Text
        [JsonProperty("childTextHTML")]
        public required string ChildTextHTML { get; set; } = null!;

        [JsonProperty("textType")]
        public string TextTypeStr
        {
            get { return TextType.ToString(); }
            private set { TextType = value.ParseEnum<TextType>(); }
        }

        [JsonIgnore]
        public required TextType TextType { get; set; }


        [JsonProperty("textColor")]
        public string TextColorStr
        {
            get { return TextColor.ToString(); }
            private set { TextColor = value.ParseEnum<TextColor>(); }
        }

        [JsonIgnore]
        public required TextColor TextColor { get; set; }
    }
}
