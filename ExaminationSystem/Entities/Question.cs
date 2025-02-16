using ExaminationSystem.Entities.Enums;

namespace ExaminationSystem.Entities
{
    public class Question : BaseModel
    {
        public string Content { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public QuestionLevel Level { get; set; }
        

        public ICollection<Choice> Choices { get; set; } = [];
        public Course Course { get; set; } = default!;
        public Instructor Instructor { get; set; } = default!;

        public ICollection<Exam> Exams { get; set; } = [];
        public List<ExamQuestion> ExamQuestions { get; set; } = [];
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = [];


    }
}
