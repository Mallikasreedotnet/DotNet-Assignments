﻿namespace SchoolManagement.Core.Dtos
{
    public class StudentExamDto
    {
        public string StudentFname { get; set; } = null!;
        public string? StudentLname { get; set; }
        public string CourseName { get; set; } = null!;
        public string ExamName { get; set; } = null!;
        public string ExamTypeName { get; set; } = null!;
        public string GradeName { get; set; } = null!;
        public string? Result { get; set; } 
        public string? ExamGrade { get; set; }
        public int Marks { get; set; }
    }
}
