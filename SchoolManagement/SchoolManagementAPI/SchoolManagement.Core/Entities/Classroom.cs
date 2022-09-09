using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public partial class Classroom
    {
        public int ClassroomId { get; set; }
        public int Year { get; set; }
        public int GradeId { get; set; }
        public string Section { get; set; } = null!;
        public bool Status { get; set; }
        public string Remarks { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; } = null!;

    }
}
