namespace ExaminationSystem.Entities
{
    public class Instructor : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Exam> Exams { get; set; } = [];
        public ICollection<Question> Questions { get; set; } = [];
    }
}
