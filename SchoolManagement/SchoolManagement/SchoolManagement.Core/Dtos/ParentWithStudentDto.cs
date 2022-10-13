namespace SchoolManagement.Core.Dtos
{
    public class ParentWithStudentDto
    {
        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
    }
}
