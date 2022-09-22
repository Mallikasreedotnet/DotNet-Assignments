using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<Grade>> GetGradeAsync()
        {
            return await _gradeRepository.GetGradeAsync();
        }

        public async Task<Grade> GetGradeAsync(int gradeId)
        {
           return await _gradeRepository.GetGradeAsync(gradeId);
        }

        public async Task<Grade> CreateGradeAsync(Grade grade)
        {
           return await _gradeRepository.CreateGradeAsync(grade);
        }

        public async Task<Grade?> UpdateGradeAsync(int gradeId, Grade grade)
        {
            var gradeToBeUpdated = await GetGradeAsync(gradeId);
            gradeToBeUpdated.Description = grade.Description;
            gradeToBeUpdated.GradeName = grade.GradeName;
            var data = await _gradeRepository.UpdateGradeAsync(gradeToBeUpdated);
            return data;
        }

        public async Task<Grade> DeleteAsync(int gradeId)
        {
           return await _gradeRepository.DeleteAsync(gradeId);
        }

        public async Task<GradeCourseDto> GetGradeCourseAsync(int gradeId)
        {
            return await _gradeRepository.GetGradeCourseAsync(gradeId);
        }

        public async Task<Grade> GetNotRepeatedDataForGrade(string gradeName, string description)
        {
            return await _gradeRepository.GetNotRepeatedDataForGrade(gradeName, description);
        }
    }
}
