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
            var query = "execute spGetCourse";
            var courseData = await _dbconnection.QueryAsync<Course>(query);
            return courseData;
        }

        public async Task<Course> GetCourseAsync(int courseId)
        {
            var query = "execute spGetCourseId @CourseId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Course>(query, new { courseId }));
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {

            _schoolDbContext.Courses.Add(course);
            await _schoolDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            _schoolDbContext.Courses.Update(course);
            await _schoolDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteAsync(int courseId)
        {
            var deletedToBeCourse = await GetCourseAsync(courseId);
            _schoolDbContext.Courses.Remove(deletedToBeCourse);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeCourse;
        }
        public async Task<Course> GetCourseName(string Name,int gradeId)
        {
            var avaliableName = "execute spGetCourseAvaliable @gradeId,@Name";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Course>(avaliableName, new { Name , gradeId }));
        }
    }
}
