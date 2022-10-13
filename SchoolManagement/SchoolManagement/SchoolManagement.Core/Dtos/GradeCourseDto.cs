namespace SchoolManagement.Core.Dtos
{
    public class GradeCourseDto
    {
        public string GradeName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int Year { get; set; }
        public string Section { get; set; } = null!;
        public string TeacherFname { get; set; } = null!;
        public string? TeacherLname { get; set; }
        public string Phone { get; set; } = null!;
    }
}
