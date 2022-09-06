using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public class ExamResult
    {
        public int ExamId { get; set; }
        public int Student_id { get; set; }
        public int CourseId { get; set; }
        public string? Marks { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Exam Exam { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
