using ExaminationSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
    }
}
