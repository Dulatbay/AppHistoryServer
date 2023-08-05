using AppHistoryServer.Models.Variant;

namespace AppHistoryServer.Dtos.QuestionDtos
{
    public class QuestionPostDto
    {
        public string? QuestionText { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public int CorrectVariantIndex { get; set; }
        public int TopicId { get; set; }
        public int QuizId { get; set; }
        public int ArchiveBookId { get; set; }
    }
}
