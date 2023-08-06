using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class Question : IModelId
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = null!;

        // Variants can be ImageQuestion or TextQuestion
        public ICollection<Variant.Variant> Variants { get; set; } = null!;

        public int CorrectVarianIndex { get; set; }

        public Topic Topic { get; set; } = null!;

        public User Author { get; set; } = null!;
        public int Level { get; set; }

        // the question may be in some test
        public ArchiveBook? ArchiveBook { get; set; } = null!;

        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<PassedUserQuestions>? PassedUserQuestions { get; set; }


        public Question()
        {

        }

        public Question(QuestionPostDto question, User author, Topic topic, ArchiveBook? archiveBook, Quiz? quiz)
        {
            QuestionText = question.QuestionText;
            Variants = question.Variants;
            CorrectVarianIndex = question.CorrectVariantIndex;
            Author = author;
            Topic = topic;
            ArchiveBook = archiveBook;
            Level = question.Level;
            if (quiz != null)
                Quizzes.Add(quiz);
        }

    }
}
