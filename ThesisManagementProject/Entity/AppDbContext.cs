using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ThesisManagementProject.Models;

namespace ThesisManagementProject.Entity
{
    internal class AppDbContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Thesis> Thesis { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<ThesisStatus> ThesisStatus { get; set; }
        public DbSet<Technology> Technology { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.conStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasKey(t => t.IdAccount);
            modelBuilder.Entity<Thesis>().HasKey(t => t.IdThesis);
            modelBuilder.Entity<Member>().HasKey(t => new { t.IdTeam, t.IdAccount });
            modelBuilder.Entity<Tasks>().HasKey(t => t.IdTask);
            modelBuilder.Entity<Comment>().HasKey(t => t.IdComment);
            modelBuilder.Entity<Evaluation>().HasKey(t => t.IdEvaluation);
            modelBuilder.Entity<Notification>().HasKey(t => t.IdNotification);
            modelBuilder.Entity<ThesisStatus>().HasKey(t => new { t.IdTeam, t.IdThesis });
            modelBuilder.Entity<Technology>().HasKey(t => new { t.Field, t.Tech });
        }
    }
}
