using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradeDto>> GetGradeAsync();
        Task<GradeDto> GetGradeAsync(int gradeId);
        Task<Grade> GetGradeByIdAsync(int gradeId);
        Task<Grade> CreateGradeAsync(Grade grade);
        Task<Grade> UpdateGradeAsync(Grade grade);
        Task<Grade> DeleteAsync(int gradeId);
        Task<GradeCourseDto> GetGradeCourseAsync(int gradeId);
        Task<Grade> GetNotRepeatedDataForGrade(string gradeName, string description);
    }
}
