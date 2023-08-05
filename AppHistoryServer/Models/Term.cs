using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class Term : IModelId
    {
        public int Id { get; set; }
        public int TermText { get; set; }
        public string Description { get; set; } = null!;
        public Topic Topic { get; set; } = null!;
    }
}
