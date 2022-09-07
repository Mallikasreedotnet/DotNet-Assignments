using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamAsync();
        Task<Exam> GetExamAsync(int examId);
        Task<Exam> CreateExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(int examId, Exam exam);
        Task<Exam> DeleteAsync(int classroomId);
        Task<IEnumerable<ExamType>> GetExamTypeAsync();
        Task<ExamType> GetExamTypeAsync(int examTypeId);
        Task<ExamType> CreateExamTypeAsync(ExamType examType);
        Task<ExamType> UpdateExamTypeAsync(int examTypeId, ExamType examType);
        Task<ExamType> DeleteExamTypeAsync(int examTypeId);

    }
}
