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

        public async Task<ExamResult> CreateExamResultAsync(ExamResult examResult)
        {
            _schoolDbContext.ExamResults.Add(examResult);
            await _schoolDbContext.SaveChangesAsync();
            return examResult;
        }

        public async Task<ExamResult> GetExamDetailsWithId(int examId,int studentId,int courseId)
        {
            var avaliableName = "select * from examResult where examId=@examId and studentId=@studentId and courseId=@courseId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamResult>(avaliableName, new { examId,studentId,courseId }));
        }
    }
}
