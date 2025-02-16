namespace ExaminationSystem.Entities
{
    public class Student : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Exam> Exams { get; set; } = [];
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = [];
    }
}
