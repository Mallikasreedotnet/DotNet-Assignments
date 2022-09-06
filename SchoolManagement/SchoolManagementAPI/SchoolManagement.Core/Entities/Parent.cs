using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Entities
{
    public class Parent
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }
        [Key]
        public int Parent_id { get; set; }
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

        public virtual ICollection<Student> Students { get; set; }
    }
}
