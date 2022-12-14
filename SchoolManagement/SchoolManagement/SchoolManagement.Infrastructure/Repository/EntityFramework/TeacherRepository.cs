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

        public async Task<IEnumerable<TeacherDto>> GetTeacherAsync()
        {
            var query = "select * from Teacher";
            var teacherData = await _dbconnection.QueryAsync<TeacherDto>(query);
            return teacherData;
        }

        public async Task<TeacherDto> GetTeacherAsync(int teacherId)
        {
            var query = "select * from Teacher where TeacherId=@TeacherId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<TeacherDto>(query, new { teacherId }));

        }

        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            var query = "select * from Teacher where TeacherId=@TeacherId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Teacher>(query, new { teacherId }));

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
            var deletedToBeTeacher = await GetTeacherByIdAsync(teacherId);
            _schoolDbContext.Teachers.Remove(deletedToBeTeacher);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeTeacher;
        }

        public async Task<ClassroomTeacherDto> GetTeacherWithClass(int teacherId)
        {
            var teacherWithClassroomRecord = await (from teacher in _schoolDbContext.Teachers
                                                    join classroom in _schoolDbContext.Classrooms
                                                    on teacher.TeacherId equals classroom.TeacherId
                                                    join grade in _schoolDbContext.Grades
                                                    on classroom.GradeId equals grade.GradeId
                                                    join course in _schoolDbContext.Courses
                                                    on classroom.GradeId equals course.CourseId
                                                    where teacher.TeacherId == teacherId
                                                    select new ClassroomTeacherDto
                                                    {
                                                        TeacherFname = teacher.Fname,
                                                        TeacherLname = teacher.Lname,
                                                        Section = classroom.Section,
                                                        CourseName = course.CourseName,
                                                        GradeName = grade.GradeName
                                                    }).FirstAsync();
            return teacherWithClassroomRecord;
        }
    }
}
