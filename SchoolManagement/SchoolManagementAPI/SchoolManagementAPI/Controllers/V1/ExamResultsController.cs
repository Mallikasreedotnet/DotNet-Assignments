using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Services;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class ExamResultController : ApiControllerBase
    {
        private readonly IExamResultService _examResultService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ExamResultController(IExamResultService examresultService, ILogger<AttendanceController> logger, IMapper mapper)
        {
            _examResultService = examresultService;
            _logger = logger;
            _mapper = mapper;
        }

        // Post Course
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ExamResultVm examResultVm)
        {
            var available = await _examResultService.GetExamDetailsWithId(examResultVm.ExamId, examResultVm.StudentId,examResultVm.CourseId);
            if (available != null /*&& available.ExamId == examResultVm.ExamId && available.StudentId == examResultVm.StudentId && available.CourseId==examResultVm.CourseId*/)
            {
                return BadRequest("ExamResult already exist");
            }
            _logger.LogInformation("Add new data for ExamResult");
            var Data = _mapper.Map<ExamResultVm, ExamResult>(examResultVm);
            var result = await _examResultService.CreateExamResultAsync(Data);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

    }
}
