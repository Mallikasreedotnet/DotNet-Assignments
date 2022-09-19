using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public TeacherRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Teacher>> GetTeacherAsync()
        {
            var query = "execute spGetTeacher";
            var teacherData = await _dbconnection.QueryAsync<Teacher>(query);
            return teacherData;
        }

        public async Task<Teacher> GetTeacherAsync(int teacherId)
        {
            var query = "execute spGetTeacherId @TeacherId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Teacher>(query, new { teacherId }));
            
        }

        public async Task<ClassroomDto> GetTeacherWithClass(int teacherId)
        {
            var teacherWithClassroomRecord = await(from teacher in _schoolDbContext.Teachers
                                             join classroom in _schoolDbContext.Classrooms
                                             on teacher.TeacherId equals classroom.TeacherId
                                             join grade in _schoolDbContext.Grades
                                             on classroom.GradeId equals grade.GradeId
                                             join course in _schoolDbContext.Courses
                                             on classroom.GradeId equals course.CourseId
                                             where teacher.TeacherId == teacherId
                                             select new ClassroomDto
                                             {
                                                 TeacherFname=teacher.Fname,
                                                 TeacherLname=teacher.Lname,
                                                 Section=classroom.Section,
                                                 CourseName=course.Name,
                                                 GradeName=grade.Name
                                             }).FirstAsync();
            return teacherWithClassroomRecord;
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            _schoolDbContext.Teachers.Add(teacher);
            await _schoolDbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateAsync(Teacher teacher)
        {
            _schoolDbContext.Teachers.Update(teacher);
            await _schoolDbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteAsync(int teacherId)
        {
            var deletedToBeTeacher= await GetTeacherAsync(teacherId);
            _schoolDbContext.Teachers.Remove(deletedToBeTeacher);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeTeacher;
        }
    }
}
