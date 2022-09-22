using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModel
{
    public class ClassroomStudentVm
    {
        [Required]
        public int ClassroomId { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
