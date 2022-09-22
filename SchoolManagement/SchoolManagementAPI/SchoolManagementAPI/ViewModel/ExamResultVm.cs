using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModel
{
    public class ExamResultVm
    {
        [Required]
        public int ExamId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        
        public string Marks { get; set; } = null!;

    }
}
