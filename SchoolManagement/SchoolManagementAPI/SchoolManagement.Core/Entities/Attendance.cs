using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public class Attendance
    {
        public DateTime Date { get; set; }
        public int Student_id { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
    }
}
