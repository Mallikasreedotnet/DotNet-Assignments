namespace SchoolManagement.Core.Dtos
{
    public class GradeDto
    {
        public int? GradeId { get; set; }
        public string GradeName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
