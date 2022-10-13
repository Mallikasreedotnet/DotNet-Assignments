using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{
    public class ExamTypeVm
    {
        [StringLength(25), Required]
        public string ExamTypeName { get; set; } = null!;
        [StringLength(25), Required]
        public string Description { get; set; } = null!;
    }
}
