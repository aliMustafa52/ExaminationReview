namespace ExaminationSystem.Entities
{
    public class ExamStudent : BaseModel
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }

        public Exam Exam { get; set; } = default!;
        public Student Student { get; set; } = default!;
    }
}
