using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.VariantDtos;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.QuestionDtos
{
    public class QuestionDto : IDtoModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = null!;
        public ICollection<VariantDto> Variants { get; set; } = null!;

        public QuestionDto(Question question)
        {
            if(question.QuestionText == null) throw new ArgumentNullException(nameof(question.QuestionText));
            if(question.Variants == null) throw new ArgumentNullException(nameof(question.Variants));
            
            Id = question.Id;
            QuestionText = question.QuestionText;
            
            foreach(var variant in question.Variants)
            {
                Variants.Add(new VariantDto(variant));
            }
        }
    }
}
