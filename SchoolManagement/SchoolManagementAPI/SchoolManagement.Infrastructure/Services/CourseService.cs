using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetCourseAsync()
        {
            return await _courseRepository.GetCourseAsync();
        }

        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await _courseRepository.GetCourseAsync(courseId);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            return await _courseRepository.CreateCourseAsync(course);
        }

        public async Task<Course> UpdateCourseAsync(int courseId, Course course)
        {
            var courseToBeUpdated = await GetCourseAsync(courseId);
            courseToBeUpdated.Description = course.Description;
            courseToBeUpdated.CourseName = course.CourseName;
            courseToBeUpdated.GradeId = course.GradeId;
            var data = await _courseRepository.UpdateCourseAsync(courseToBeUpdated);
            return data;
        }

        public async Task<Course> DeleteAsync(int courseId)
        {
            return await _courseRepository.DeleteAsync(courseId);
        }

        public async Task<Course> GetCourseName(string Name,int gradeId)
        {
            return await _courseRepository.GetCourseName(Name,gradeId);
        }

        public async Task<Course> GetCourseWithCourseName(string? courseName)
        {
            return await _courseRepository.GetCourseWithCourseName(courseName);
        }
    }
}
