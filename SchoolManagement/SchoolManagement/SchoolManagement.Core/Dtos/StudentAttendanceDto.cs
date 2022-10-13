namespace SchoolManagement.Core.Dtos
{
    public class StudentAttendanceDto
    {
        public string StudentFname { get; set; } = null!;
        public string? StudentLname { get; set; }
        public string StudentEmail { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!; 

    }
}
