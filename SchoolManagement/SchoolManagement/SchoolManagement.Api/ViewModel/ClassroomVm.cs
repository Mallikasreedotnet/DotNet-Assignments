using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{
    public class ClassroomVm
    {
        public int Year { get; set; }
        [Required]
        public int GradeId { get; set; }
        [Required]
        public string Section { get; set; } = null!;
        public bool Status { get; set; }
        public string Remarks { get; set; } = null!;
        [Required]
        public int TeacherId { get; set; }
    }
}
