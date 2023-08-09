using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Utils.Initializer
{
    public class ModuleInitializer
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            Module module = new Module()
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Level = 1,
                Minutes = 10,
                Number = 1,
            };

            var node = new Node() { Id = 1, Component = Component.Stack, TopicId = 1 };
            modelBuilder.Entity<Node>().HasData(node);

            Topic topic = new Topic()
            {
                Id = 1,
                Title = "Test",
                ContentId = node.Id, // Используйте Id узла как связь
                ModuleId = module.Id,
                Number = 1
            };

            modelBuilder.Entity<Topic>().HasData(topic);
            modelBuilder.Entity<Module>().HasData(module);
        }

    }
}
