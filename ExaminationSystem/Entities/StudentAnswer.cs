namespace ExaminationSystem.Entities
{
    public class StudentAnswer : BaseModel
    {
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public int ChoiceId { get; set; }


        public Student Student { get; set; } = default!;
        public Question Question { get; set; } = default!;
        public Exam Exam { get; set; } = default!;
        public Choice Choice { get; set; } = default!;
    }
}
