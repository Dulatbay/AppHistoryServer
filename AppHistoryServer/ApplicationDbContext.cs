﻿using AppHistoryServer.Models;
using Microsoft.EntityFrameworkCore;


namespace AppHistoryServer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasMany(c => c.FavoritedQuizzes)
                    .WithMany(s => s.AddedFavoritedUsers)
                    .UsingEntity(j => j.ToTable("FavoritedUserQuizzes"));


        }
    }
}
