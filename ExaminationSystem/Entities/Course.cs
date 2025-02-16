namespace ExaminationSystem.Entities
{
    public class Course : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Hours { get; set; }

        

        public ICollection<Exam> Exams { get; set; } = [];
        public ICollection<Question> Questions { get; set; } = [];


        // List of courses that this course depends on
        public ICollection<CoursePrerequisite> Prerequisites { get; set; } = [];

        // List of courses that depend on this course
        public ICollection<CoursePrerequisite> DependentCourses { get; set; } = [];



    }
}
