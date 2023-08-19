using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.VariantDtos;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.QuestionDtos
{
    public class QuestionDto : IDtoModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = null!;
        public ICollection<VariantDto> Variants { get; set; } = new List<VariantDto>();
        public int Level { get; set; }
        public int CorrectVariantIndex { get; set; }
        public int TopicId { get; set; }
        public string? TopicTitle { get; set; }
        public QuestionDto(Question? question)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));
            if (question.QuestionText == null) throw new ArgumentNullException(nameof(question.QuestionText));
            if (question.Variants == null) throw new ArgumentNullException(nameof(question.Variants));

            Id = question.Id;
            QuestionText = question.QuestionText;
            Level = question.Level;
            CorrectVariantIndex = question.CorrectVarianIndex;
            TopicId = question.TopicId;
            if (question.Topic != null)
                TopicTitle = question.Topic.Title;

            foreach (var variant in question.Variants)
            {
                Variants.Add(new VariantDto(variant));
            }
        }

        public static IEnumerable<QuestionDto> GetAll(IEnumerable<Question>? questions)
        {
            if (questions == null)
                yield break;

            foreach (var question in questions)
            {
                yield return new QuestionDto(question);
            }
        }
    }
}
