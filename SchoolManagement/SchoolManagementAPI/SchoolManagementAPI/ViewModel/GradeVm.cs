using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModel
{
    public class GradeVm
    {
        [StringLength(30), Required]
        public string GradeName { get; set; } = null!;

        [StringLength(30), Required]
        public string Description { get; set; } = null!;
    }
}
