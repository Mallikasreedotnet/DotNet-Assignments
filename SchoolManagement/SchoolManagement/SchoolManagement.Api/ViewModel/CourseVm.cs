using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{
    public class CourseVm
    {
        [StringLength(25), Required]
        public string CourseName { get; set; } = null!;
        [StringLength(25)]
        public string Description { get; set; } = null!;
        [Required]
        public int GradeId { get; set; }
    }
}
