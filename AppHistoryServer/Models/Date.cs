using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class Date : IModelId
    {
        public int Id { get; set; }
        public int DateNumber { get; set; }
        public string Description { get; set; } = null!;
        public Topic Topic { get; set; } = null!;
    }
}
