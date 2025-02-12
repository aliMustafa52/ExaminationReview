namespace ExaminationSystem.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int QuizId { get; set; }

        public ICollection<Choice> Choices { get; set; } = [];
        public Quiz Quiz { get; set; } = default!;
    }
}
