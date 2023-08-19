using AppHistoryServer.Dtos;
using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Variant;
using AppHistoryServer.Repositories.Interfaces;

namespace AppHistoryServer.Utils
{
    public static class QuizUtils
    {
        public static void CheckModel(QuizPostDto model)
        {
            if (model.Questions == null || model.Questions.Count < 2)
                throw new BadHttpRequestException("Квиз должен содержать минимум 3 вопроса.");

            if (model.Title == null)
                throw new BadHttpRequestException("Квиз должен содержать тему.");
            if (model.Description == null)
                throw new BadHttpRequestException("Квиз должен содержать описание.");
        }

        public static async Task<ICollection<Question>> SetQuestionsAsync(QuizPostDto quizPostDto, IQuestionRepository questionRepository, IVariantRepository variantRepository, User author, ITopicRepository topicRepository)
        {
            var resultQuestions = new List<Question>();

            if (quizPostDto.Questions == null)
                throw new ArgumentNullException(nameof(quizPostDto.Questions));

            foreach (var question in quizPostDto.Questions)
            {
                if (question == null) continue;

                var existQuestion = await questionRepository.GetByIdAsync(question.Id);

                if (existQuestion == null)
                {
                    question.Author = author;
                    question.Topic = await topicRepository.GetByIdAsync(question.TopicId == null ? 0 : (int)question.TopicId);

                    await QuestionUtils.SetVariants(question, variantRepository);

                    existQuestion = await questionRepository.SaveAsync(question);
                }

                resultQuestions.Add(existQuestion);
            }

            return resultQuestions;
        }

        public static float GetAverageResult(QuizPassedDto quizPassedDto, Quiz existingQuiz)
        {
            var correctAnswers = 0;
            for (int i = 0; i < quizPassedDto.ChoosesIndex.Count; i++)
            {
                if (existingQuiz.Questions[i].CorrectVarianIndex == quizPassedDto.ChoosesIndex[i])
                    correctAnswers++;
            }

            return (correctAnswers / existingQuiz.Questions.Count) * 100;
        }

        public static float GetAverageResult(Quiz quiz)
        {
            var passedQuizzes = quiz.PassedUserQuizzes;
            if (passedQuizzes.Count == 0) return 0;
            float result = 0f;
            foreach (var passedQuiz in passedQuizzes)
            {
                var correctAnswers = 0;
                foreach (var passedQuestion in passedQuiz.PassedQuestions)
                {
                    if (passedQuestion.ChooseIndex == passedQuestion.Question.CorrectVarianIndex) 
                        correctAnswers++;
                }
                result += ((float)((float)correctAnswers / (float)passedQuiz.PassedQuestions.Count)) * 100f;
            }
            return (result / (float)passedQuizzes.Count);
        }
    }
}
