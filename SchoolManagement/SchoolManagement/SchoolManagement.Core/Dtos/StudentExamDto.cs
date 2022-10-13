using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Dtos
{
    public class StudentExamDto
    {
        public string StudentFname { get; set; } = null!;
        public string StudentLname { get; set; } = null!;
        public string ExamTypeName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string ExamName { get; set; } = null!;
        public string GradeName { get; set; } = null!;
        public int Marks { get; set; }
        public string Result { get; set; } = null!;
        public string ExamGrade { get; set; } = null!;

    }
}
