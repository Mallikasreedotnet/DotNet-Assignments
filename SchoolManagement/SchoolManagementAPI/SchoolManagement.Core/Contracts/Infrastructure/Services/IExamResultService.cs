using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IExamResultService
    {
        Task<ExamResult> CreateExamResultAsync(ExamResult examResult);
        Task<IEnumerable<ExamResultDto>> GetExamResultAsync();
        Task<ExamResultDto> GetExamResultAsync(int examResultId);
        Task<ExamResult> GetExamResultByIdAsync(int examResultId);
        Task<ExamResult> UpdateExamResultAsync(int examResultId, ExamResult examResult);
        Task<ExamResult> DeleteAsync(int examResultId);
        Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId);
        public (string,string) GetExamResultForPassOrFail(int marks);
     
    }
}
