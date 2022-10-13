using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{
    public class TeacherVm
    {
        [StringLength(100), Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [StringLength(25), Required]
        public string Fname { get; set; } = null!;

        [StringLength(25), Required]
        public string? Lname { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Phone { get; set; } = null!;

        [Required]
        public string Mobile { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; } = null!;
    }
}
