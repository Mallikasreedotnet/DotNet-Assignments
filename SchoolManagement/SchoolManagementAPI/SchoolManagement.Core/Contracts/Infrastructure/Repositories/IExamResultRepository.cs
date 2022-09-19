using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IExamResultRepository
    {
        Task<ExamResult> CreateExamResultAsync(ExamResult examResult);
        Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId);
    }
}
