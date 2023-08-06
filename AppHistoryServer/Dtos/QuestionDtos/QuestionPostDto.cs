using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models.Interfaces;
using AppHistoryServer.Models.Variant;

namespace AppHistoryServer.Dtos.QuestionDtos
{
    public class QuestionPostDto : IDtoModel
    {
        public string? QuestionText { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public int CorrectVariantIndex { get; set; }
        public int TopicId { get; set; }
        public int QuizId { get; set; }
        public int Level { get; set; }
        public int ArchiveBookId { get; set; }
    }
}
