namespace SchoolManagement.Core.Dtos
{
    public class ClassroomDto
    {
        public int ClassroomId { get; set; }
        public int Year { get; set; }
        public string GradeName { get; set; } = null!;
        public string Section { get; set; } = null!;
        public bool Status { get; set; }
        public string Remarks { get; set; } = null!;
        public string TeacherFname { get; set; } = null!;
        public string? TeacherLname { get; set; }
    }
}
