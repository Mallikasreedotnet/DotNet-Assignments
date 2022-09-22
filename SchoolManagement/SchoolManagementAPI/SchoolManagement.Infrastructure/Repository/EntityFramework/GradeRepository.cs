using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        
        public GradeRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbConnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbConnection;
        }
        public async Task<IEnumerable<Grade>> GetGradeAsync()
        {
            var query = "execute spGetGrade";
            var result = await _dbconnection.QueryAsync<Grade>(query);
            return result;
        }

        public async Task<Grade> GetGradeAsync(int gradeId)
        {
            var query = "execute spGetGradeId @gradeId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Grade>(query, new { gradeId }));
        }

        public async Task<Grade> CreateGradeAsync(Grade grade)
        {
            _schoolDbContext.Grades.Add(grade);
            await _schoolDbContext.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> UpdateGradeAsync(Grade grade)
        {
            _schoolDbContext.Grades.Update(grade);
            await _schoolDbContext.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> DeleteAsync(int gradeId)
        {
            var deletedToBeGrade = await GetGradeAsync(gradeId);
            _schoolDbContext.Grades.Remove(deletedToBeGrade);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeGrade;
        }

        public async Task<GradeCourseDto> GetGradeCourseAsync(int gradeId)
        {
            var gradeResult = await( from grade in _schoolDbContext.Grades
                              join course in _schoolDbContext.Courses
                              on grade.GradeId equals course.GradeId
                              join classroom in _schoolDbContext.Classrooms
                              on grade.GradeId equals classroom.GradeId
                              join teacher in _schoolDbContext.Teachers
                              on classroom.TeacherId equals teacher.TeacherId
                              where grade.GradeId == gradeId
                              select new GradeCourseDto
                              {
                                  GradeName=grade.GradeName,
                                  CourseName=course.CourseName,
                                  Year=classroom.Year,
                                  Section=classroom.Section,
                                  TeacherFname=teacher.Fname,
                                  TeacherLname=teacher.Lname,
                                  Phone=teacher.Phone,
                              }).FirstAsync();
            return gradeResult;
        }

        public async Task<Grade> GetNotRepeatedDataForGrade(string gradeName,string description)
        {
            var repeatedData = "Select * from Grade where gradeName=@gradeName and description=@description";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Grade>(repeatedData, new { gradeName, description }));
        }
    }
}
