using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Entities
{
    [Table("Grade")]
    public class Grade
    {
        public Grade()
        {
            Classrooms = new HashSet<Classroom>();
            Courses = new HashSet<Course>();
        }
        
        public int? GradeId { get; set; }
        public string GradeName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
