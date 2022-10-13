using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IExamRepository _examRepository;
        private readonly IDbConnection _dbconnection;
        public ExamResultRepository(SchoolManagementDbContext schoolDbContext, IExamRepository examRepository, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _examRepository = examRepository;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<ExamResultDto>> GetExamResultAsync()
        {
            var query = "execute spGetExamResult";
            var ExamData = await _dbconnection.QueryAsync<ExamResultDto>(query);
            return ExamData;
        }

        public async Task<ExamResultDto> GetExamResultAsync(int examResultId)
        {
            var query = "execute spGetExamResultId @examResultId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamResultDto>(query, new { examResultId }));
        }

        public async Task<ExamResult> GetExamResultByIdAsync(int examResultId)
        {
            var query = "Select * from ExamResult where ExamResultId=@examResultId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamResult>(query, new { examResultId }));
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
            var deletedToBeExamResult = await GetExamResultByIdAsync(examResultId);
            _schoolDbContext.ExamResults.Remove(deletedToBeExamResult);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeExamResult;
        }

        public async Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId)
        {
            var avaliableName = "execute spGetExamResultDetails @examId, @studentId, @courseId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ExamResult>(avaliableName, new { examId, studentId, courseId }));
        }

        //public async Task<IEnumerable<StudentExamDto>> GetStudentResultPassOrFail(int studentId, int? examTypeId = null)
        //{
        //    var studentMarks = "execute spGetExamResultDetails @studentId,@examTypeId";
        //    return await _dbconnection.QueryAsync<StudentExamDto>(studentMarks, new { studentId, examTypeId });
        //}

        public async Task<IEnumerable<StudentTotalMarksDto>> GetStudentTotalMarksWithPassOrFail(int studentId)
        {
            var studentResult = "execute spGetTotalMarks @studentId";
            return await _dbconnection.QueryAsync<StudentTotalMarksDto>(studentResult, new { studentId });
        }
    }
}
