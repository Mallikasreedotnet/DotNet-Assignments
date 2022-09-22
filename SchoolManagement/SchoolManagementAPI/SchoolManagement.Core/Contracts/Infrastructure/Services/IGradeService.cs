using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetGradeAsync();
        Task<Grade> GetGradeAsync(int gradeId);
        Task<Grade> CreateGradeAsync(Grade grade);
        Task<Grade?> UpdateGradeAsync(int gradeId, Grade grade);
        Task<Grade> DeleteAsync(int gradeId);
        Task<GradeCourseDto> GetGradeCourseAsync(int gradeId);
        Task<Grade> GetNotRepeatedDataForGrade(string gradeName, string description);
    }
}
