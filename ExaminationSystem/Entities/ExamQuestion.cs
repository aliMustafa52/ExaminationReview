namespace ExaminationSystem.Entities
{
    public class ExamQuestion : BaseModel
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int Grade { get; set; }

        public Exam Exam { get; set; } = default!;
        public Question Question { get; set; } = default!;
    }
}
