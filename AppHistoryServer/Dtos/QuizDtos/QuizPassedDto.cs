using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizPassedDto : IDtoModel
    {
        public int QuizId { get; set; }
        public IList<int> ChoosesIndex { get; set; } = new List<int>();   
    }
}
