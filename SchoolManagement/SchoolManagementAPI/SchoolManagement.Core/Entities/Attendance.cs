namespace SchoolManagement.Core.Entities
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
    }
}
