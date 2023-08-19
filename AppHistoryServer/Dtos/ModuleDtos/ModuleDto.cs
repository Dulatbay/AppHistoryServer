using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.ModuleDtos
{
    public class ModuleDto : IDtoModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Minutes { get; set; }
        public int Number { get; set; }
        public int TopicsCount { get; set; }
        public string? ImageUrl { get; set; }
        public int QuestionsCount { get; set; }
        public int PassedUsersCount { get; set; }
        public int Level { get; set; }

        public ModuleDto(Module? module, int questionsCount = 0, int passedUsersCount = 0)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            Id = module.Id;
            Title = module.Title;
            Description = module.Description;
            Minutes = module.Minutes;
            Number = module.Number;
            TopicsCount = module.Topics.Count;
            ImageUrl = "https://localhost:7279/api/static/" + module.ImageUrl;
            QuestionsCount = questionsCount;
            PassedUsersCount = passedUsersCount;
            Level = module.Level;
        }

        public static IEnumerable<ModuleDto> GetAll(IEnumerable<Module>? modules)
        {
            if (modules == null)
                yield break;
            
            foreach (var module in modules)
            {
                yield return new ModuleDto(module);
            }
        }
    }
}
