namespace SchoolManagement.Core.Dtos
{
    public class UserDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
