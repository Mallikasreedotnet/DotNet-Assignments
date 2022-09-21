using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public ExamResultRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<ExamResult>> GetExamResultAsync()
        {
            var query = "execute spGetExamResult";
            var ExamData = await _dbconnection.QueryAsync<ExamResult>(query);
            return ExamData;
        }

        public async Task<ExamResult> GetExamResultAsync(int examResultId)
        {
            var query = "execute spGetExamResultId @examResultId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamResult>(query, new {examResultId}));
        }

        public async Task<ExamResult> CreateExamResultAsync(ExamResult examResult)
        {
            _schoolDbContext.ExamResults.Add(examResult);
            await _schoolDbContext.SaveChangesAsync();
            return examResult;
        }

        public async Task<ExamResult> UpdateExamResultAsync(ExamResult examResult)
        {
            _schoolDbContext.ExamResults.Update(examResult);
            await _schoolDbContext.SaveChangesAsync();
            return examResult;
        }

        public async Task<ExamResult> DeleteAsync(int examResultId)
        {
            var deletedToBeExamResult = await GetExamResultAsync(examResultId);
            _schoolDbContext.ExamResults.Remove(deletedToBeExamResult);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExamResult;
        }

        public async Task<ExamResult> GetExamDetailsWithId(int examId,int studentId,int courseId)
        {
            var avaliableName = "execute spGetExamResultDetails @examId, @studentId, @courseId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamResult>(avaliableName, new { examId,studentId,courseId }));
        }
    }
}
