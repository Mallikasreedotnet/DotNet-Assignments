namespace SchoolManagement.Core.Dtos
{
    public class ClassroomDto
    {
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; } = null!;
        public int ClassroomId { get; set; }
        public string Section { get; set; } = null!;
    }
}
