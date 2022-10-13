using System.ComponentModel.DataAnnotations;

namespace JWT.Authentication.Server.Infrastructure.ViewModel
{
    public class LoginVm
    {
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
