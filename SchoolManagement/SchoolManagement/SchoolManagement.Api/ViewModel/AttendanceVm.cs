using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.ViewModel
{
    public class AttendanceVm
    {
        public DateTime Date { get; set; }
        [Required]
        public int StudentId { get; set; }
        public bool Status { get; set; }
        [StringLength(100)]
        public string Remark { get; set; } = null!;
    }
}
