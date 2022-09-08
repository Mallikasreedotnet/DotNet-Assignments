using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classrooms = new HashSet<Classroom>();
        }
       // [Key]
        public int TeacherId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; } = null!;

        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
