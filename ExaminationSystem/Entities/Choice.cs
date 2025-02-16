namespace ExaminationSystem.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; } = true;

        public int QuestionId { get; set; }
        public Question Question { get; set; } = default!;
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = [];
    }
}
