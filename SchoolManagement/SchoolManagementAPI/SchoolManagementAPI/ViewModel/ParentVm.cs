namespace SchoolManagementAPI.ViewModel
{
    public class ParentVm
    {
      
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Phone { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; } = null!;
       
        
    }
}
