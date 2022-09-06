using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public class ClassroomStudent
    {
        public int ClassroomId { get; set; }
        public int Student_id { get; set; }

        public virtual Classroom Classroom { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;

    }
}
