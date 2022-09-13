using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModel
{
    public class ExamTypeVm
    {
        [StringLength(25), Required]
        public string Name { get; set; } = null!;
        [StringLength(25), Required]
        public string Description { get; set; } = null!;
    }
}
