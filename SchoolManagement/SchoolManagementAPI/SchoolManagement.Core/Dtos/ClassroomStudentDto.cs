namespace SchoolManagement.Core.Dtos
{
    public class ClassroomStudentDto
    {
        public int ClassroomStudentId { get; set; }
        public int ClassroomId { get; set; }
        public string StudentFname { get; set; } = null!;
        public string StudentLname { get; set; } = null!;
    }
}
