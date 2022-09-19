using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IExamResultService
    {
        Task<ExamResult> CreateExamResultAsync(ExamResult examResult);
        Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId);
    }
}
