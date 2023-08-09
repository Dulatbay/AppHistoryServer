using AppHistoryServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Utils.Initializer
{
    public static class UserInitializer
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            var user1 = new User { Id = 1, UserName = "user1", Email = "user1@example.com", Password = "test1" };
            var user2 = new User { Id = 2, UserName = "user2", Email = "user2@example.com", Password = "test2" };
            var user3 = new User { Id = 3, UserName = "user3", Email = "user3@example.com", Password = "test3" };
            modelBuilder.Entity<User>().HasData(user1, user2, user3);
        }
    }
}
