using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Dtos
{
    public class ExamDto
    {
        public string Name { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string? Marks { get; set; }
        public int courseId { get; set; } 


    }
}
