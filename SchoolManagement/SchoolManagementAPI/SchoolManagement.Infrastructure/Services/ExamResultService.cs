using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class ExamResultService : IExamResultService
    {

        private readonly IExamResultRepository _examResultRepository;
        public ExamResultService(IExamResultRepository examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }

        public async Task<IEnumerable<ExamResult>> GetExamResultAsync()
        {
            return await _examResultRepository.GetExamResultAsync();
        }

        public async Task<ExamResult> GetExamResultAsync(int examResultId)
        {
            return await _examResultRepository.GetExamResultAsync(examResultId);
        }

        public async Task<ExamResult> CreateExamResultAsync(ExamResult examResult)
        {
            return await _examResultRepository.CreateExamResultAsync(examResult);
        }

        public async Task<ExamResult> UpdateExamResultAsync(int examResultId, ExamResult examResult)
        {
            var examResultToBeUpdated = await GetExamResultAsync(examResultId);
            examResultToBeUpdated.ExamId= examResult.ExamId;
            examResultToBeUpdated.StudentId= examResult.StudentId;
            examResultToBeUpdated.CourseId= examResult.CourseId;
            examResultToBeUpdated.Marks= examResult.Marks;  
            var data= await _examResultRepository.UpdateExamResultAsync(examResultToBeUpdated);
            return data;
        }

        public async Task<ExamResult> DeleteAsync(int examResultId)
        {
            return await _examResultRepository.DeleteAsync(examResultId);
        }

        public async Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId)
        {
            return await _examResultRepository.GetExamDetailsWithId(examId, studentId, courseId);
        }
    }
}
