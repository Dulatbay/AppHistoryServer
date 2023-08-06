using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizPostDto : IDtoModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public bool? IsVerified { get; set; }
        public int Level { get; set; }
    }
}
