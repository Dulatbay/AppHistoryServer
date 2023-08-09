using AppHistoryServer.Models.Interfaces;
using Newtonsoft.Json;

namespace AppHistoryServer.Models.Variant
{
    public class Variant : IModelId
    {
        public int Id { get; set; }
        public string? Content { get; set; }

        [JsonIgnore]
        public ICollection<Question>? Questions { get; set; }
    }
}
