namespace SchoolManagement.Core.Dtos
{
    public class ClassroomDto
    {
        public string TeacherFname { get; set; } = null!;
        public string? TeacherLname { get; set; } = null!;
        public string Section { get; set; } = null!;

        public string GradeName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
    }
}
