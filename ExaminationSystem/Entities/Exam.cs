using ExaminationSystem.Entities.Enums;

namespace ExaminationSystem.Entities
{
    public class Exam : BaseModel
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public ExamType Type { get; set; }

        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public ICollection<Question> Questions { get; set; } = [];
        public List<ExamQuestion> ExamQuestions { get; set; } = [];

        public ICollection<Student> Students { get; set; } = [];

        public Course Course { get; set; } = default!;
        public Instructor Instructor { get; set; } = default!;
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = [];
    }
}
