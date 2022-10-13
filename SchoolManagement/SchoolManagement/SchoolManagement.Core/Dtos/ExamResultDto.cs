namespace SchoolManagement.Core.Dtos
{
    public class ExamResultDto
    {
        public int ExamResultId { get; set; }
        public string ExamName { get; set; } = null!;
        public string  StudentFname { get; set; } = null!;
        public string StudentLname { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string Result { get; set; } = null!;
        public string ExamGrade { get; set; } = null!;
        public int Marks { get; set; }
    }
}
