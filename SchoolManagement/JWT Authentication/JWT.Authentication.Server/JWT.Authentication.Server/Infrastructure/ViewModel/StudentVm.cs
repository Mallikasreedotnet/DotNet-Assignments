using System.ComponentModel.DataAnnotations;

namespace JWT.Authentication.Server.Infrastructure.ViewModel
{
    public class StudentVm
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public int ParentId { get; set; }
        public bool Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; } = null!;
        public DateTime? DateOfJoin { get; set; }


    }
}
