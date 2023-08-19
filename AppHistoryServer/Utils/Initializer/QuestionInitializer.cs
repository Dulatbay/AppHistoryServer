
using AppHistoryServer.Models;
using AppHistoryServer.Models.Variant;

namespace AppHistoryServer.Utils.Initializer
{
    public class QuestionInitializer
    {
        public static void InitQuestions(ApplicationDbContext dbContext)
        {
            var variant1 = new Variant()
            {
                Content = "Алаш, Букеевская Орда"
            };
            var variant2 = new Variant()
            {
                Content = "Туркестанская автономия, Алаш"
            };
            var variant3 = new Variant()
            {
                Content = "Букеевская Орда, Семиреченская автономия"
            };
            var variant4 = new Variant()
            {
                Content = "Алаш, Семиреченская автономия"
            };

            dbContext.Variants.AddRange(variant1, variant2, variant3, variant4);
            dbContext.SaveChanges();


            var quesiton = new Question
            {
                Level = 1,
                QuestionText = "Автономии, образованные на территории Казахстана в ноябре-декабре 1917 года",
                CorrectVarianIndex = 1,
                Variants = new List<Variant> { variant1, variant2, variant3, variant4 },
                TopicId = 37,
            };

            dbContext.Questions.Add(quesiton);
            dbContext.SaveChanges();








            variant1 = new Variant()
            {
                Content = "Ж.Нажимеденов и Н.Назарбаев"
            };
            variant2 = new Variant()
            {
                Content = "Ш.Калдаяков"
            };
            variant3 = new Variant()
            {
                Content = "Ш.Ниязбеков"
            };
            variant4 = new Variant()
            {
                Content = "Ж.Малибеков,Ш.Уалиханов"
            };
            dbContext.Variants.AddRange(variant1, variant2, variant3, variant4);
            dbContext.SaveChanges();


            quesiton = new Question
            {
                Level = 1,
                QuestionText = "Автор герба",
                CorrectVarianIndex = 3,
                Variants = new List<Variant> { variant1, variant2, variant3, variant4 },
                TopicId = 47,
            };
            dbContext.Questions.Add(quesiton);
            dbContext.SaveChanges();
            
            
            
            
            
            
            
            
            
            variant1 = new Variant()
            {
                Content = "Уральская область и Внутренняя орда"
            };
            variant2 = new Variant()
            {
                Content = "Уральская область и Внешняя орда"
            };
            variant3 = new Variant()
            {
                Content = "Тургайская и Акмолинская области"
            };
            variant4 = new Variant()
            {
                Content = "Уральская и Тургайская области"
            };
            dbContext.Variants.AddRange(variant1, variant2, variant3, variant4);
            dbContext.SaveChanges();


            quesiton = new Question
            {
                Level = 2,
                QuestionText = "По уставу 1867-68 в состав Оренбургского генерал-губернаторства вошли",
                CorrectVarianIndex = 3,
                Variants = new List<Variant> { variant1, variant2, variant3, variant4 },
                TopicId = 29,
            };
            dbContext.Questions.Add(quesiton);
            dbContext.SaveChanges();
        }
    }
}
