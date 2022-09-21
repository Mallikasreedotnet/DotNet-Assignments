namespace SchoolManagement.Core.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; } = null!;
    }
}
