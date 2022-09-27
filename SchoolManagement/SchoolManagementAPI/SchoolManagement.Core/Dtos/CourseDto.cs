namespace SchoolManagement.Core.Dtos
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string GradeName { get; set; } = null!;
    }
}
