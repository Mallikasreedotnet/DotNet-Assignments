using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Entities
{
    public partial class ExamResult
    {
        public int ExamResultId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? Marks { get; set; }
    }
}
