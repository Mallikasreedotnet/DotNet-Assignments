using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetGradeAsync();
        Task<Grade> GetGradeAsync(int gradeId);
        Task<Grade> CreateGradeAsync(Grade grade);
        Task<Grade> UpdateGradeAsync(int gradeId, Grade grade);
    }
}
