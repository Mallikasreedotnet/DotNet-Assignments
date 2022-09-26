using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("exam")]
   
    public class ExamController : ApiControllerBase
    {
        private readonly IExamService _examService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private int examId;

        public ExamController(IExamService examService, ILogger<ExamController> logger, IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Exam
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all Exams");
            var result = await _examService.GetExamAsync();
            return Ok(result);
        }


        // Get Exam {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of Exam by ID:{id}", id);
            var result = await _examService.GetExamAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Exam
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ExamVm examVm)
        {
            _logger.LogInformation("Add new data for Exam");
            var Data = _mapper.Map<ExamVm, Exam>(examVm);
            var result = await _examService.CreateExamAsync(Data);
            return Ok(result);
        }

        // Put Exam {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ExamVm examVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var data = _mapper.Map<ExamVm, Exam>(examVm);
            var result = await _examService.UpdateExamAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Delete Exam {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var existingData=await _examService.GetExamAsync(id);
            if (existingData != null)
            {
                var result = await _examService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Exam not found");
        }


        // Get ExamTypes
        [MapToApiVersion("1.0")]
        [Route("type")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetExamType()
        {
            _logger.LogInformation("Getting list of all ExamTpye");
            var result = await _examService.GetExamTypeAsync(); ;
            return Ok(result);
        }


        // Get ExamType {id}
        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("type/{id}")]       
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetExamType(int id)
        {
            _logger.LogInformation("Getting list of ExamTpye by ID:{id}", id);
            var result = await _examService.GetExamTypeAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post ExamType
        [MapToApiVersion("1.0")]
        [Route("type")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ExamTypeVm examTypeVm)
        {
            var repeatedData = await _examService.GetNotRepeationData(examTypeVm.ExamTypeName, examTypeVm.Description);
            if(repeatedData != null)
            {
                return BadRequest("Examtype is already exist");
            }
            _logger.LogInformation("Add new data for courses");
            var Data = _mapper.Map<ExamTypeVm, ExamType>(examTypeVm);
            var result = await _examService.CreateExamTypeAsync(Data);
            return Ok(result);
        }

        // Put ExamType {id}
        [MapToApiVersion("1.0")]
        [HttpPut]
        [Route("type/{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ExamTypeVm examTypeVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var repeatedData = await _examService.GetNotRepeationData(examTypeVm.ExamTypeName, examTypeVm.Description);
            if (repeatedData != null)
            {
                return BadRequest("Examtype is already exist");
            }
            var data = _mapper.Map<ExamTypeVm, ExamType>(examTypeVm);
            var result = await _examService.UpdateExamTypeAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Delete ExamType {id}
        [MapToApiVersion("1.0")]
        [Route("type/{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> DeleteExamType(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var existingData=await _examService.GetExamTypeAsync(id);
            if (existingData != null)
            {
                var result = await _examService.DeleteExamTypeAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Examtype not found");
        }

        // Get ExamType Details
        [MapToApiVersion("1.0")]
        [Route("examdetails/{studentId}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetExamTypeDetails(int? studentId,int? examTypeId,int? courseId)
        {
            var result= await _examService.GetExamDetails(studentId, examTypeId,courseId);
            return Ok(result);
        }

    }
}
