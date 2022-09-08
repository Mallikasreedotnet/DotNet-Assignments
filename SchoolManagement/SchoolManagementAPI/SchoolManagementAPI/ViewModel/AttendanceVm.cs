namespace SchoolManagementAPI.ViewModel
{
    public class AttendanceVm
    {
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!;
    }
}
