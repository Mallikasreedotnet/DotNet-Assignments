using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{
    public class ClassroomStudentVm
    {
        [Required]
        public int ClassroomId { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
