namespace SchoolManagement.Core.Entities
{
    public partial class ExamResult
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Marks { get; set; } =null!;

        public virtual Student Student { get; set; } = null!;
    }
}
