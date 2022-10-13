namespace SchoolManagement.Core.Dtos
{
    public class StudentTotalMarksDto
    {
        public int StudentId { get; set; }
        public string StudentFname { get; set; } = null!;
        public string StudentLname { get; set; } = null!;
        public string ExamTypeName { get; set; } = null!;
        public int TotalMarks { get; set; }
        public Char Grade { get; set; }
        public string Result { get; set; } = null!;
    }
}
