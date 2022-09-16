using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourseAsync();
        Task<Course> GetCourseAsync(int courseId);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int courseId, Course course);
        Task<Course> DeleteAsync(int courseId);
        Task<Course> GetCourseName(string Name,int gradeId);
    }
}
