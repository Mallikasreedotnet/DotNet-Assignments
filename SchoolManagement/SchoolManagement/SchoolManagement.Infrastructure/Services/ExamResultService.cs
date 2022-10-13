using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class ExamResultService : IExamResultService
    {

        private readonly IExamResultRepository _examResultRepository;
        private readonly IExamRepository _examRepository;
        public ExamResultService(IExamResultRepository examResultRepository, IExamRepository examRepository)
        {
            _examResultRepository = examResultRepository;
            _examRepository = examRepository;
        }

        public async Task<IEnumerable<ExamResultDto>> GetExamResultAsync()
        {
            return await _examResultRepository.GetExamResultAsync();
        }

        public async Task<ExamResultDto> GetExamResultAsync(int examResultId)
        {
            return await _examResultRepository.GetExamResultAsync(examResultId);
        }

        public async Task<ExamResult> GetExamResultByIdAsync(int examResultId)
        {
            return await _examResultRepository.GetExamResultByIdAsync(examResultId);
        }

        public async Task<ExamResult> CreateExamResultAsync(ExamResult examResult)
        {
            var examResultOutput = GetExamResultForPassOrFail(examResult.Marks);
            examResult.Result = examResultOutput.Item1;
            examResult.ExamGrade = examResultOutput.Item2;
            var examResults = await _examResultRepository.CreateExamResultAsync(examResult);
            return examResults;
            

        }
        //public async Task<int> GetTotalMarksPassOrFail(int studentId)
        //{
            
        //    var studentExamResultData = await _examRepository.GetExamDetails(studentId: studentId);

        //    var groupExamResult = studentExamResultData.GroupBy(e => e.ExamTypeName);
        //    var totalMarks = groupExamResult.Select(x => new
        //    {
        //        Marks = x.Sum(x => x.Marks)
        //    });
        //    return 0;


        //}

        public async Task<ExamResult> UpdateExamResultAsync(int examResultId, ExamResult examResult)
        {
            var examResultToBeUpdated = await GetExamResultByIdAsync(examResultId);
            examResultToBeUpdated.ExamId = examResult.ExamId;
            examResultToBeUpdated.StudentId = examResult.StudentId;
            examResultToBeUpdated.CourseId = examResult.CourseId;
            examResultToBeUpdated.Marks = examResult.Marks;
            var examResultOutput = GetExamResultForPassOrFail(examResult.Marks);
            examResultToBeUpdated.Result = examResultOutput.Item1;
            examResultToBeUpdated.ExamGrade = examResultOutput.Item2;
            var data = await _examResultRepository.UpdateExamResultAsync(examResultToBeUpdated);
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

        public (string,string) GetExamResultForPassOrFail(int marks)
        {
            string examResult;
            string examGrade;
            if (marks >= 75)
            {
                examResult= "Pass";
                examGrade = "A+";
                return (examResult, examGrade);
            }
            else if (marks >= 65 && marks < 75)
            {
                examResult = "Pass";
                examGrade = "A";
                return (examResult, examGrade);
            }
            else if (marks >= 55 && marks < 65)
            {
                examResult="Pass";
                examGrade = "B";
                return (examResult, examGrade);
            }
            else if (marks >= 40 && marks < 55)
            {
                examResult = "Pass";
                examGrade = "C";
                return (examResult, examGrade);
            }
            else
                examResult = "Fail";
                examGrade = "D";
            return (examResult, examGrade);
        }

        //public string GetStudentTotalMarks(IEnumerable<StudentExamDto> studentResult)
        //{

        //    var result = studentResult.All(result => result.Result == "Pass");
        //    if(result == true)
        //    {
        //        return "Pass";
        //    }
        //    return "Fail";
        //}

        public async Task<IEnumerable<StudentTotalMarksDto>> GetStudentTotalMarksWithPassOrFail(int studentId)
        {
            return await _examResultRepository.GetStudentTotalMarksWithPassOrFail(studentId);
        }
    }
}

