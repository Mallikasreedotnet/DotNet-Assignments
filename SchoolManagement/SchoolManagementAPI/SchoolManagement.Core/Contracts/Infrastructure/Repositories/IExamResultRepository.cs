using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IExamResultRepository
    {
        Task<ExamResult> CreateExamResultAsync(ExamResult examResult);
        Task<IEnumerable<ExamResultDto>> GetExamResultAsync();
        Task<ExamResult> GetExamResultAsync(int examResultId);
        Task<ExamResult> UpdateExamResultAsync(ExamResult examResult);
        Task<ExamResult> DeleteAsync(int examResultId);
        Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId);
    }
}
