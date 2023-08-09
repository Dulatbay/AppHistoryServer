using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizDetailDto : IDtoModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<QuestionDtos.QuestionDto> QuestionDtos { get; set; } = null!;
        public float AverageResult { get; set; }
        public bool IsFavorited { get; set; }
        public int FavoritedCount { get; set; }
        public AuthorDto AuthorDto { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public QuizDetailDto(Quiz quiz, AuthorDto authorDto,float averageResult, bool isFavorited, int favoritedCount, string imageUrl)
        {
            if(quiz.Description == null) throw new ArgumentNullException(nameof(quiz.Description));
            Id = quiz.Id;
            Title = quiz.Title;
            Description = quiz.Description;
            AuthorDto = authorDto;
            AverageResult = averageResult;
            IsFavorited = isFavorited;
            FavoritedCount = favoritedCount;
            ImageUrl = imageUrl;
        }

    }
}
