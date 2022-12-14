using Dapper;
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

        public async Task<IEnumerable<ExamDto>> GetExamAsync()
        {
            var query = "execute spGetExam";
            var ExamData = await _dbconnection.QueryAsync<ExamDto>(query);
            return ExamData;
        }

        public async Task<ExamDto> GetExamAsync(int examId)
        {
            var query = "execute spGetExamId @examId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamDto>(query, new { examId }));
        }

        public async Task<Exam> GetExamByIdAsync(int examId)
        {
            var query = "select * from Exam where ExamId=@examId";
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
            var deletedToBeExam = await GetExamByIdAsync(ExamId);
            _schoolDbContext.Exams.Remove(deletedToBeExam);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExam;
        }

        // Exam Type
        public async Task<IEnumerable<ExamTypeDto>> GetExamTypeAsync()
        {
            var query = "select * from ExamType";
            var courseData = await _dbconnection.QueryAsync<ExamTypeDto>(query);
            return courseData;
        }

        public async Task<ExamTypeDto> GetExamTypeAsync(int examTypeId)
        {
            var query = "select * from examtype where ExamTypeId=@examTypeId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamTypeDto>(query, new { examTypeId }));
        }

        public async Task<ExamType> GetExamTypeByIdAsync(int examTypeId)
        {
            var query = "select * from examtype where ExamTypeId=@examTypeId";
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

        public async Task<ExamType> DeleteExamTypeAsync(int examTypeId)
        {
            var deletedToBeExamType = await GetExamTypeByIdAsync(examTypeId);
            _schoolDbContext.ExamTypes.Remove(deletedToBeExamType);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExamType;
        }

        public async Task<IEnumerable<StudentExamDto>> GetExamDetails(int studentId, int? examTypeId = null, int? courseId = null)
        {
            var examResults = "execute spGetExamResultDetails @studentId , @examTypeId , @courseId";
            var data = await _dbconnection.QueryAsync<StudentExamDto>(examResults, new { studentId, examTypeId, courseId });
            return data;
        }


        public async Task<ExamType> GetNotRepeationData(string examTypeName,string description)
        {
            var repeationData = "Select * from ExamType where ExamTypeName=@examTypeName and Description=@description";
            return await _dbconnection.QueryFirstOrDefaultAsync<ExamType>(repeationData, new { examTypeName, description });
        }
    }
}
