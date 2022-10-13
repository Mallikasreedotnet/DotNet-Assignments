using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{

    public class LoginVm
    {
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        public string User { get; set; } = null!;

    }
}
