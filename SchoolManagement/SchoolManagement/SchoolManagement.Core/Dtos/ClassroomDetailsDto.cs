namespace SchoolManagement.Core.Dtos
{
    public class ClassroomDetailsDto
    {
        public int StudentId { get; set; } 
        public string StudentFname { get; set; } = null!;
        public string? StudentLname { get; set; } = null!;
        public string GradeName { get; set; } = null!;
        public int Year { get; set; }
        public string Section { get; set; } = null!;
    } 
}
