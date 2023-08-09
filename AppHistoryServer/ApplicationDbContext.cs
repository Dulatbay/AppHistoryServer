using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Enums;
using AppHistoryServer.Models.Variant;
using AppHistoryServer.Utils.Initializer;
using Microsoft.EntityFrameworkCore;


namespace AppHistoryServer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ArchiveBook> ArchiveBooks { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            //Database.EnsureDeleted();

            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasMany(c => c.FavoritedQuizzes)
                    .WithMany(s => s.AddedFavoritedUsers)
                    .UsingEntity(j => j.ToTable("FavoritedUserQuizzes"));

            modelBuilder.Entity<Quiz>()
                    .HasOne(c => c.Author)
                    .WithMany(c => c.CreatedQuizzes)
                    .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Topic>()
                    .HasOne(c => c.Module)
                    .WithMany(c => c.Topics)
                    .HasForeignKey(c => c.ModuleId);

            modelBuilder.Entity<Question>()
                    .HasOne(c => c.Topic)
                    .WithMany(c => c.Questions)
                    .HasForeignKey(c => c.TopicId);



            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Content)
                .WithOne(c => c.Topic)
                .HasForeignKey<Node>(c => c.TopicId);


            modelBuilder.Entity<Quiz>()
            .Property(q => q.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
            .Property(q => q.CreateAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
            .Property(q => q.League)
            .HasDefaultValue(League.LittleBoy);


            ModuleInitializer.Initialize(modelBuilder);
           



        }
    }
}
