using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models.Variant
{
    public class Variant : IModelId
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Index { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}
