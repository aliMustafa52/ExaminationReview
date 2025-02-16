using ExaminationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExaminationSystem.Persistence
{
    public class ApplicationDbContext
        : DbContext
    {

        
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Exam> Exams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-UCB0QUC;Database=ExaminationSystem;Trusted_Connection=true;Encrypt=false");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
