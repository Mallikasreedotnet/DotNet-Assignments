using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.EntityConfiguration;

namespace SchoolManagement.Infrastructure.Extensions
{
    internal static class ModelBuilderExtensions
    {
        internal static void RegisterEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomStudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExamEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExamResultEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GradeEntityTypeConfiguration());

        }
    }
}
