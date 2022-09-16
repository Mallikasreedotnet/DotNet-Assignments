using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ExamRepository : IExamRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public ExamRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Exam>> GetExamAsync()
        {
            var query = "execute spGetExam";
            var ExamData = await _dbconnection.QueryAsync<Exam>(query);
            return ExamData;
        }

        public async Task<Exam> GetExamAsync(int examId)
        {
            var query = "execute spGetExamId @examId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Exam>(query, new { examId }));
        }

        public async Task<Exam> CreateExamAsync(Exam exam)
        {
            _schoolDbContext.Exams.Add(exam);
            await _schoolDbContext.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam> UpdateExamAsync(Exam exam)
        {
            _schoolDbContext.Exams.Update(exam);
            await _schoolDbContext.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam> DeleteAsync(int ExamId)
        {
            var deletedToBeExam = await GetExamAsync(ExamId);
            _schoolDbContext.Exams.Remove(deletedToBeExam);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExam;
        }

        // Exam Type
        public async Task<IEnumerable<ExamType>> GetExamTypeAsync()
        {
            var query = "execute spGetExamType";
            var courseData = await _dbconnection.QueryAsync<ExamType>(query);
            return courseData;
        }

        public async Task<ExamType> GetExamTypeAsync(int examTypeId)
        {
            var query = "execute spGetExamTypeId @examTypeId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamType>(query, new { examTypeId }));
        }

        public async Task<ExamType> CreateExamTypeAsync(ExamType examType)
        {
            _schoolDbContext.ExamTypes.Add(examType);
            await _schoolDbContext.SaveChangesAsync();
            return examType;
        }

        public async Task<ExamType> UpdateExamTypeAsync(ExamType examType)
        {
            _schoolDbContext.ExamTypes.Update(examType);
            await _schoolDbContext.SaveChangesAsync();
            return examType;
        }

        public async Task<IEnumerable<StudentExamDto>> GetExamDetails(int? studentId = 0, int? examTypeId = 0, int? courseId = 0)
        {
                var examResults = await (from examType in _schoolDbContext.ExamTypes
                                         join exam in _schoolDbContext.Exams
                                         on examType.ExamTypeId equals exam.ExamTypeId
                                         join examResult in _schoolDbContext.ExamResults
                                         on exam.ExamId equals examResult.ExamId
                                         join student in _schoolDbContext.Students 
                                         on examResult.StudentId equals student.StudentId
                                         join course in _schoolDbContext.Courses
                                         on examResult.CourseId equals course.CourseId
                                         join grade in _schoolDbContext.Grades
                                         on course.GradeId equals grade.GradeId
                                         where (studentId == 0 || student.StudentId == studentId)
                                         &&(examTypeId == 0 || exam.ExamTypeId == examTypeId)
                                         &&(courseId == 0 || course.CourseId == courseId)
                                         select new StudentExamDto
                                         {
                                             StudentFname = student.Fname,
                                             StudentLname = student.Lname,
                                             CourseName = course.Name,
                                             ExamName = exam.Name,
                                             ExamTypeName = examType.Name,
                                             Marks = examResult.Marks,
                                             GradeName = grade.Name
                                         }).ToListAsync();
                return examResults;
        }

        public async Task<ExamType> DeleteExamTypeAsync(int examTypeId)
        {
            var deletedToBeExamType = await GetExamTypeAsync(examTypeId);
            _schoolDbContext.ExamTypes.Remove(deletedToBeExamType);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExamType;
        }
    }
}
