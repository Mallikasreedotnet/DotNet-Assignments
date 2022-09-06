using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int ExamTypeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }

        public virtual ExamType ExamType { get; set; } = null!;
    }
}
