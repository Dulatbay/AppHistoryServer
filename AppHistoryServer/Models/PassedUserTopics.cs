using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class PassedUserTopics : IModelId
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Topic Topic { get; set; } = null!;
        public double PassedPercent { get; set; } 
    }
}
