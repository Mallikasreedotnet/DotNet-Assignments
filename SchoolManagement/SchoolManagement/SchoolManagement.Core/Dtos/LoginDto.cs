namespace SchoolManagement.Core.Dtos
{
    public class LoginDto
    {
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PasswordSalt { get; set; }
        public string? Password { get; set; }
    }
}
