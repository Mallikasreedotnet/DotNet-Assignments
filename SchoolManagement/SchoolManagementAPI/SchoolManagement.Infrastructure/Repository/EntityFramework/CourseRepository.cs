using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public CourseRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Course>> GetCourseAsync()
        {
            var query = "select * from [Course]";
            var courseData = await _dbconnection.QueryAsync<Course>(query);
            return courseData;
        }

        public async Task<Course> GetCourseAsync(int courseId)
        {
            var query = "Select * from Course where courseId=@CourseId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Course>(query, new { courseId }));
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            _schoolDbContext.Courses.Add(course);
            await _schoolDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourseAsync(int courseId, Course course)
        {
            var courseToBeUpdated = await GetCourseAsync(courseId);
            courseToBeUpdated.Description = course.Description;
            courseToBeUpdated.Name = course.Name;
            courseToBeUpdated.GradeId = course.GradeId;
            _schoolDbContext.Courses.Update(courseToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return courseToBeUpdated;
        }

        public async Task<Course> DeleteAsync(int courseId)
        {
            var deletedToBeCourse = await GetCourseAsync(courseId);
            _schoolDbContext.Courses.Remove(deletedToBeCourse);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeCourse;
        }
    }
}
