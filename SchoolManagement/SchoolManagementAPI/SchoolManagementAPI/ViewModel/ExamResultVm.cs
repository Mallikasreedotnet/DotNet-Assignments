namespace SchoolManagementAPI.ViewModel
{
    public class ExamResultVm
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Marks { get; set; } = null!;

    }
}
