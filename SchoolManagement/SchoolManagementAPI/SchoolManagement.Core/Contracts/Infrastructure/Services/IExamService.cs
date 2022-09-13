using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetExamAsync();
        Task<Exam> GetExamAsync(int examId);
        Task<Exam> CreateExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(int ExamId,Exam exam);
        Task<Exam> DeleteAsync(int ExamId);
        Task<IEnumerable<ExamType>> GetExamTypeAsync();
        Task<ExamType> GetExamTypeAsync(int examTypeId);
        Task<ExamType> CreateExamTypeAsync(ExamType examType);
        Task<ExamType> UpdateExamTypeAsync(int examTypeId,ExamType examType);
        Task<ExamType> DeleteExamTypeAsync(int examTypeId);
    }
}
