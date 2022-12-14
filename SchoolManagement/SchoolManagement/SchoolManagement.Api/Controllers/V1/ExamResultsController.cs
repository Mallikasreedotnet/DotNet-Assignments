using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Infrastructure.Specs;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("examresult")]
    public class ExamResultController : ApiControllerBase
    {
        private readonly IExamResultService _examResultService;
        private readonly IExamResultRepository _examResultRepository;
        private readonly IExamRepository _examRepository;
        private readonly IExamService _examService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        //  public Exception? Id { get; private set; }

        public ExamResultController(IExamResultService examResultService, IExamResultRepository examResultRepository, IExamRepository examRepository, IExamService examService, ILogger<ExamResultController> logger, IMapper mapper)
        {
            _examResultService = examResultService;
            _examResultRepository = examResultRepository;
            _examRepository = examRepository;
            _examService = examService;
            _logger = logger;
            _mapper = mapper;
        }

        // Get ExamResult
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher,student")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all ExamResults");
            var result = await _examResultService.GetExamResultAsync();
            return Ok(result);
        }

        // Get ExamResult {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of ExamResult by ID:{id}", id);
            var result = await _examResultService.GetExamResultAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post ExamResult
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ExamResultVm examResultVm)
        {
            var available = await _examResultService.GetExamDetailsWithId(examResultVm.ExamId, examResultVm.StudentId, examResultVm.CourseId);
            if (available != null)
            {
                return BadRequest("ExamResult already exist");
            }
            _logger.LogInformation("Add new data for ExamResult");
            var Data = _mapper.Map<ExamResultVm, ExamResult>(examResultVm);
            var result = await _examResultService.CreateExamResultAsync(Data);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // Put ExamResult {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ExamResultVm examResultVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var available = await _examResultService.GetExamDetailsWithId(examResultVm.ExamId, examResultVm.StudentId, examResultVm.CourseId);
            if (available != null)
            {
                return BadRequest("ExamResult already exist");
            }
            var data = _mapper.Map<ExamResultVm, ExamResult>(examResultVm);
            var result = await _examResultService.UpdateExamResultAsync(id, data);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Delete ExamResult {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var existingData = await _examResultService.GetExamResultAsync(id);
            if (existingData != null)
            {
                var result = await _examResultService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Examresult not found");
        }


        [HttpGet()]
        [Route("totalmarks/{studentId}")]
        [Authorize(Roles = "student,teacher")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetStudentMarksDetails(int studentId)
        {
            var result = await _examResultRepository.GetStudentTotalMarksWithPassOrFail(studentId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
