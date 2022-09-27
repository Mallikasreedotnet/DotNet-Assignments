namespace SchoolManagement.Core.Dtos
{
    public class ExamDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; } = null!;
        public string ExamTypeName { get; set; } = null!;
        public DateTime StartDate { get; set; }
    }
}
