using AppHistoryServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AppHistoryServer.Utils.Initializer
{
    public static class UserInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var user1 = new User { Username = "user1", Email = "user1@example.com", Password = "test1" };
            var user2 = new User { Username = "user2", Email = "user2@example.com", Password = "test2" };
            var user3 = new User { Username = "user3", Email = "user3@example.com", Password = "test3" };
            context.Users.AddRange(user1, user2, user3);
            context.SaveChanges();
        }
    }
}
