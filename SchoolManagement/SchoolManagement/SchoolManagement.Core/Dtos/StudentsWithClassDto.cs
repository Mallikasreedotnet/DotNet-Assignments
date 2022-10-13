namespace SchoolManagement.Core.Dtos
{
    public class StudentsWithClassDto
    {
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }=null!;
        public string GradeName { get; set; } = null!;
        public int Year { get; set; }
        public string Section { get; set; } = null!;
        public int ClassroomId { get; set; }
    }
}
