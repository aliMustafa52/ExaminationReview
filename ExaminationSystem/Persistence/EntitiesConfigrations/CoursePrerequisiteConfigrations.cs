using ExaminationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationSystem.Persistence.EntitiesConfigrations
{
    public class CoursePrerequisiteConfigrations : IEntityTypeConfiguration<CoursePrerequisite>
    {
        public void Configure(EntityTypeBuilder<CoursePrerequisite> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.PrerequisiteCourseId });

            builder
                .HasOne(cp => cp.Course)
                .WithMany(c => c.Prerequisites)
                .HasForeignKey(cp => cp.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(cp => cp.PrerequisiteCourse)
                .WithMany(c => c.DependentCourses)
                .HasForeignKey(cp => cp.PrerequisiteCourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
