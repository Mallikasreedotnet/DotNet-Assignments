namespace SchoolManagement.Core.Dtos
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!;
    }
}
