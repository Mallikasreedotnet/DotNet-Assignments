using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Entities
{
    [Table("ExamType")]
    public class ExamType
    {
        public ExamType()
        {
            Exams = new HashSet<Exam>();
        }

        public int ExamTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
