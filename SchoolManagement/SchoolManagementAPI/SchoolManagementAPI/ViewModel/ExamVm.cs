using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModel
{
    public class ExamVm
    {
        [Required]
        public int ExamTypeId { get; set; }

        [StringLength(30), Required]
        public string ExamName { get; set; } = null!;
        public DateTime StartDate { get; set; }
    }
}
