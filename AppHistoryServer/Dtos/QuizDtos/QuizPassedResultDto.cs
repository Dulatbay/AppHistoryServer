using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizPassedResultDto : IDtoModel
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; } = null!;
        public string QuizDescription { get; set;} = null!;
        public float UserAvgResult { get; set; }
        public float AvgResult { get; set; }
        public ICollection<int> ChoosesIndex { get; set; } = new List<int>();
        public ICollection<QuestionDtos.QuestionDto> Questions { get; set; } = new List<QuestionDtos.QuestionDto>();

        public QuizPassedResultDto(int quizId, string quizTitle, string quizDescription, float userAvgResult, ICollection<int> choosesIndex, ICollection<QuestionDtos.QuestionDto> questions)
        {
            QuizId = quizId;
            QuizTitle = quizTitle;
            QuizDescription = quizDescription;
            UserAvgResult = userAvgResult;
            ChoosesIndex = choosesIndex;
            Questions = questions;
        }

    }
}
