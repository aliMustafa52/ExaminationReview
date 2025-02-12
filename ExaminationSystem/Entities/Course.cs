namespace ExaminationSystem.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Hours { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
