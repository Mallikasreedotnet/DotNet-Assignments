namespace SchoolManagement.Core.Dtos
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string StudentFname { get; set; } = null!;
        public string? StudentLname { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!;
    }
}
