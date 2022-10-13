using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetCourseAsync();
        Task<CourseDto> GetCourseAsync(int courseId);
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Course course);
        Task<Course> DeleteAsync(int courseId);
        Task<Course> GetCourseName(string Name,int grade);
        Task<Course> GetCourseWithCourseName(string? courseName);
    }
}
