namespace SchoolManagementAPI.ViewModel
{
    public class ClassroomVm
    {
        public int Year { get; set; }
        public int GradeId { get; set; }
        public string Section { get; set; } = null!;
        public bool Status { get; set; }
        public string Remarks { get; set; } = null!;
        public int TeacherId { get; set; }
    }
}
