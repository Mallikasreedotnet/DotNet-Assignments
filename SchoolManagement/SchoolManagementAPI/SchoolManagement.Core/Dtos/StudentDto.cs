namespace SchoolManagement.Core.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string StudentFname { get; set; } = null!;
        public string? StudentLname { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string ParentFname { get; set; } = null!;
        public string? ParentLname { get; set; }
        public bool Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; } = null!;
        public DateTime? DateOfJoin { get; set; }
    }
}
