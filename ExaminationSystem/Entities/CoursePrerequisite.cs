namespace ExaminationSystem.Entities
{
    public class CoursePrerequisite
    {
        public int CourseId { get; set; }
        public int PrerequisiteCourseId { get; set; }


        public Course Course { get; set; } = default!;
        public Course PrerequisiteCourse { get; set; } = default!;

        public bool IsMandatory { get; set; }
    }
}
