using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetExamAsync();
        Task<ExamDto> GetExamAsync(int examId);
        Task<Exam> GetExamByIdAsync(int examId);
        Task<Exam> CreateExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(int ExamId,Exam exam);
        Task<Exam> DeleteAsync(int ExamId);
        Task<IEnumerable<ExamTypeDto>> GetExamTypeAsync();
        Task<ExamTypeDto> GetExamTypeAsync(int examTypeId);
        Task<ExamType> GetExamTypeByIdAsync(int examTypeId);
        Task<ExamType> CreateExamTypeAsync(ExamType examType);
        Task<ExamType> UpdateExamTypeAsync(int examTypeId,ExamType examType);
        Task<ExamType> DeleteExamTypeAsync(int examTypeId);
        Task<IEnumerable<StudentExamDto>> GetExamDetails(int? studentId, int? examTypeId,int? courseId);
        Task<ExamType> GetNotRepeationData(string examTypeName, string description);
    }
}
