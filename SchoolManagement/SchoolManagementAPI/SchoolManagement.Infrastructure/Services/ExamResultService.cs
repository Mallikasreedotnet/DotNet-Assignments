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
        public async Task<ExamResult> CreateExamResultAsync(ExamResult examResult)
        {
            return await _examResultRepository.CreateExamResultAsync(examResult);
        }

        public async Task<ExamResult> GetExamDetailsWithId(int examId, int studentId, int courseId)
        {
            return await _examResultRepository.GetExamDetailsWithId(examId, studentId, courseId);
        }
    }
}
