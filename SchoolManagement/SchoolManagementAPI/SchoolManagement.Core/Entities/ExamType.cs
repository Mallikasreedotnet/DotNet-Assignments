using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public class ExamType
    {
        public ExamType()
        {
            Exams = new HashSet<Exam>();
        }

        public int ExamTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
