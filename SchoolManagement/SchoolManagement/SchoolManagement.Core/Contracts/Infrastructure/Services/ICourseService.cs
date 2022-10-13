using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetCourseAsync();
        Task<CourseDto> GetCourseAsync(int courseId);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int courseId, Course course);
        Task<Course> DeleteAsync(int courseId);
        Task<Course> GetCourseName(string Name,int gradeId);
        Task<Course> GetCourseWithCourseName(string? courseName);
    }
}
