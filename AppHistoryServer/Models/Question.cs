using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models.Interfaces;
using Newtonsoft.Json;

namespace AppHistoryServer.Models
{
    public class Question : IModelId
    {
        public int Id { get; set; }

        public string? QuestionText { get; set; }

        public ICollection<Variant.Variant>? Variants { get; set; }

        public int CorrectVarianIndex { get; set; }

        [JsonIgnore]
        public Topic? Topic { get; set; }

        public int TopicId { get; set; }

        [JsonIgnore]
        public User? Author { get; set; }

        public int Level { get; set; }

        // the question may be in some test

        [JsonIgnore]
        public ArchiveBook? ArchiveBook { get; set; }

        [JsonIgnore]
        public ICollection<Quiz>? Quizzes { get; set; }
        
        [JsonIgnore]
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
