using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamAsync();
        Task<Exam> GetExamAsync(int examId);
        Task<Exam> CreateExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(Exam exam);
        Task<Exam> DeleteAsync(int ExamId);
        Task<IEnumerable<ExamType>> GetExamTypeAsync();
        Task<ExamType> GetExamTypeAsync(int examTypeId);
        Task<ExamType> CreateExamTypeAsync(ExamType examType);
        Task<ExamType> UpdateExamTypeAsync(ExamType examType);
        Task<ExamType> DeleteExamTypeAsync(int examTypeId);
        Task<IEnumerable<StudentExamDto>> GetExamDetails(int? studentId, int? examTypeId,int? courseId);
        Task<ExamType> GetNotRepeationData(string examTypeName, string description);
    }
}
