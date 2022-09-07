using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
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
            var query = "select * from [Exam]";
            var ExamData = await _dbconnection.QueryAsync<Exam>(query);
            return ExamData;
        }

        public async Task<Exam> GetExamAsync(int examId)
        {
            var query = "Select * from Exam where examId=@ExamId";
            return (await _dbconnection.QueryAsync<Exam>(query, new { examId })).FirstOrDefault();
        }

        public async Task<Exam> CreateExamAsync(Exam exam)
        { 
            _schoolDbContext.Exams.Add(exam);
            await _schoolDbContext.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam> UpdateExamAsync(int examId, Exam exam)
        {
            var examToBeUpdated = await GetExamAsync(examId);
            examToBeUpdated.StartDate = exam.StartDate;
            examToBeUpdated.Name= exam.Name;
            examToBeUpdated.ExamTypeId= exam.ExamTypeId;
            _schoolDbContext.Exams.Update(examToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return examToBeUpdated;
        }

        public async Task<Exam> DeleteAsync(int classroomId)
        {
            var deletedToBeExam = await GetExamAsync(classroomId);
            _schoolDbContext.Exams.Remove(deletedToBeExam);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExam;
        }

        // Exam Type
        public async Task<IEnumerable<ExamType>> GetExamTypeAsync()
        {
            var query = "select * from [ExamType]";
            var courseData = await _dbconnection.QueryAsync<ExamType>(query);
            return courseData;
        }

        public async Task<ExamType> GetExamTypeAsync(int examTypeId)
        {
            var query = "Select * from ExamType where examTypeId=@ExamTypeId";
            return (await _dbconnection.QueryAsync<ExamType>(query, new { examTypeId })).FirstOrDefault();
        }

        public async Task<ExamType> CreateExamTypeAsync(ExamType examType)
        {
            _schoolDbContext.ExamTypes.Add(examType);
            await _schoolDbContext.SaveChangesAsync();
            return examType;
        }

        public async Task<ExamType> UpdateExamTypeAsync(int examTypeId, ExamType examType)
        {
            var examTypeToBeUpdated = await GetExamTypeAsync(examTypeId);
            examTypeToBeUpdated.Description = examType.Description;
            examTypeToBeUpdated.Name = examType.Name;
            _schoolDbContext.ExamTypes.Update(examTypeToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return examTypeToBeUpdated;
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
