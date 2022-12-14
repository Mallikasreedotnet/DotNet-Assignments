using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<IEnumerable<ExamDto>> GetExamAsync()
        {
           return await _examRepository.GetExamAsync();
        }

        public async Task<ExamDto> GetExamAsync(int examId)
        {
            return await _examRepository.GetExamAsync(examId);
        }

        public async Task<Exam> GetExamByIdAsync(int examId)
        {
            return await _examRepository.GetExamByIdAsync(examId);
        }

        public async Task<Exam> CreateExamAsync(Exam exam)
        {
            return await _examRepository.CreateExamAsync(exam);
        }

        public async Task<Exam> UpdateExamAsync(int examId, Exam exam)
        {
            var examToBeUpdated = await GetExamByIdAsync(examId);
            examToBeUpdated.StartDate = exam.StartDate;
            examToBeUpdated.ExamName = exam.ExamName;
            examToBeUpdated.ExamTypeId = exam.ExamTypeId;
           var data=await _examRepository.UpdateExamAsync(examToBeUpdated);
           return data;
        }

        public async Task<Exam> DeleteAsync(int ExamId)
        {
            return await _examRepository.DeleteAsync(ExamId);
        }

        // Exam Type
        public async Task<IEnumerable<ExamTypeDto>> GetExamTypeAsync()
        {
           return await _examRepository.GetExamTypeAsync();
        }

        public async Task<ExamTypeDto> GetExamTypeAsync(int examTypeId)
        {
            return await _examRepository.GetExamTypeAsync(examTypeId);
        }

        public async Task<ExamType> GetExamTypeByIdAsync(int examTypeId)
        {
            return await _examRepository.GetExamTypeByIdAsync(examTypeId);
        }

        public async Task<ExamType> CreateExamTypeAsync(ExamType examType)
        {
           return await _examRepository.CreateExamTypeAsync(examType);
        }

        public async Task<ExamType> UpdateExamTypeAsync(int examTypeId, ExamType examType)
        {
            var examTypeToBeUpdated = await GetExamTypeByIdAsync(examTypeId);
            examTypeToBeUpdated.Description = examType.Description;
            examTypeToBeUpdated.ExamTypeName = examType.ExamTypeName;
           var data= await _examRepository.UpdateExamTypeAsync(examTypeToBeUpdated);
            return examTypeToBeUpdated;
        }

        public async Task<ExamType> DeleteExamTypeAsync(int examTypeId)
        {
            return await _examRepository.DeleteExamTypeAsync(examTypeId);

        }

        public async Task<IEnumerable<StudentExamDto>> GetExamDetails(int studentId, int? examTypeId = null, int? courseId=null)
        {
                return await _examRepository.GetExamDetails(studentId,examTypeId,courseId);
        }

        public async Task<ExamType> GetNotRepeationData(string examTypeName, string description)
        {
            return await _examRepository.GetNotRepeationData(examTypeName,description);
        }
    }
}
