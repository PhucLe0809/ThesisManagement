using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Entity
{
    internal class AppDbContext : DbContext
    {
        public DbSet<People> Account { get; set; }
        public DbSet<Thesis> Thesis { get; set; }
        //public DbSet<Team> Teams { get; set; }
        //public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<ThesisStatus> ThesisStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.conStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasKey(t => t.IdAccount);
            modelBuilder.Entity<Thesis>().HasKey(t => t.IdThesis);
            //modelBuilder.Entity<Team>().HasKey(t => t.IdTeam);
            //modelBuilder.Entity<Tasks>().HasKey(t => t.IdTask);
            modelBuilder.Entity<Comment>().HasKey(t => t.IdComment);
            modelBuilder.Entity<Evaluation>().HasKey(t => t.IdEvaluation);
            modelBuilder.Entity<Notification>().HasKey(t => t.IdNotification);
            modelBuilder.Entity<ThesisStatus>().HasKey(t => t.IdThesis);
        }
    }
}
