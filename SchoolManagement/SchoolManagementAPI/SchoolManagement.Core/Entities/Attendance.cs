using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Entities
{
    [Table("Attendance")]
    public class Attendance
    {
        public DateTime Date { get; set; }
        public int Student_id { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
    }
}
