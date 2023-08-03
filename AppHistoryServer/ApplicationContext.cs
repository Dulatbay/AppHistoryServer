using AppHistoryServer.Models;
using Microsoft.EntityFrameworkCore;


namespace AppHistoryServer
{
  public class ApplicationContext : DbContext
  {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=AppHistory;Username=postgres;Password=123456");
        }
       
    }
}
