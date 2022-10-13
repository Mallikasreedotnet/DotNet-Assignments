namespace SchoolManagement.Core.Dtos
{
    public class ExamTypeDto
    {
        public int ExamTypeId { get; set; }
        public string ExamTypeName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
