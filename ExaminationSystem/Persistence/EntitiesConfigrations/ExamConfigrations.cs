using ExaminationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationSystem.Persistence.EntitiesConfigrations
{
    public class ExamConfigrations : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder
                .HasMany(e => e.Students)
                .WithMany(s => s.Exams)
                .UsingEntity(j => j.ToTable("ExamStudents"));

            //builder
            //    .HasMany(e => e.Questions)
            //    .WithMany(s => s.Exams)
            //    .UsingEntity(j => j.ToTable("ExamQuestions"));

            builder
                .HasMany(e => e.Questions)
                .WithMany(s => s.Exams)
                .UsingEntity<ExamQuestion>(
                        j => j.HasOne(eq => eq.Question)
                            .WithMany(q => q.ExamQuestions)
                            .HasForeignKey(eq => eq.QuestionId)
                            .OnDelete(DeleteBehavior.Restrict),
                        j => j
                            .HasOne(eq => eq.Exam)
                            .WithMany(e => e.ExamQuestions)
                            .HasForeignKey(eq => eq.ExamId)
                            .OnDelete(DeleteBehavior.Restrict),
                        j =>
                            {
                                j.ToTable("ExamQuestions");
                                j.HasKey(e => new { e.QuestionId, e.ExamId });
                            }

                );
        }
    }
}
