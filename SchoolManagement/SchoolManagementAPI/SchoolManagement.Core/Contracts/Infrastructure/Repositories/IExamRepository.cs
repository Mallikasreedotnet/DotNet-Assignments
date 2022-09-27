using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<ExamDto>> GetExamAsync();
        Task<ExamDto> GetExamAsync(int examId);
        Task<Exam> GetExamByIdAsync(int examId);
        Task<Exam> CreateExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(Exam exam);
        Task<Exam> DeleteAsync(int ExamId);
        Task<IEnumerable<ExamTypeDto>> GetExamTypeAsync();
        Task<ExamTypeDto> GetExamTypeAsync(int examTypeId);
        Task<ExamType> GetExamTypeByIdAsync(int examTypeId);
        Task<ExamType> CreateExamTypeAsync(ExamType examType);
        Task<ExamType> UpdateExamTypeAsync(ExamType examType);
        Task<ExamType> DeleteExamTypeAsync(int examTypeId);
        Task<IEnumerable<StudentExamDto>> GetExamDetails(int? studentId, int? examTypeId,int? courseId);
        Task<ExamType> GetNotRepeationData(string examTypeName, string description);
    }
}
