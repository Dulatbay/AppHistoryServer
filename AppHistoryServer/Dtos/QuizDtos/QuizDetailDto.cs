using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Utils;
using Newtonsoft.Json;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizDetailDto : IDtoModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [JsonProperty("questions")]
        public ICollection<QuestionDtos.QuestionDto> QuestionsDtos { get; set; } = new List<QuestionDtos.QuestionDto>();
        public float AverageResult { get; set; }
        public bool IsFavorited { get; set; }
        public int FavoritedCount { get; set; }
        public AuthorDto AuthorDto { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public QuizDetailDto(Quiz? quiz, bool isFavorited = false, int favoritedCount = 0)
        {
            if (quiz == null) throw new ArgumentNullException(nameof(quiz));
            if (quiz.Description == null) throw new ArgumentNullException(nameof(quiz.Description));
            Id = quiz.Id;
            Title = quiz.Title;
            Description = quiz.Description;
            AuthorDto = new AuthorDto(quiz.Author.Id, quiz.Author.Username);
            AverageResult = QuizUtils.GetAverageResult(quiz);
            IsFavorited = isFavorited;
            FavoritedCount = favoritedCount;
            if (quiz.ImageUrl != null)
                ImageUrl = "https://localhost:7279/api/" + quiz.ImageUrl;
            QuestionsDtos = QuestionDtos.QuestionDto.GetAll(quiz.Questions).ToList();
        }
    }
}
