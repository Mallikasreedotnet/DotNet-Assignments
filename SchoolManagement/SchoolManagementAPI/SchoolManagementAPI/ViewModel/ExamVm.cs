namespace SchoolManagementAPI.ViewModel
{
    public class ExamVm
    {
        public int ExamTypeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
    }
}
