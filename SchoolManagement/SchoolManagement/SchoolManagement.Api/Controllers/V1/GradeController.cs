using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Infrastructure.Specs;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("grade")]
    public class GradeController : ApiControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GradeController(IGradeService gradeSrevice, IMapper mapper, ILogger<GradeController> logger)
        {
            _gradeService = gradeSrevice;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Grades
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all grades");
            var result = await _gradeService.GetGradeAsync();
            return Ok(result);
        }


        // Get Grade {id}
        [MapToApiVersion("1.0")]
        [Route("{gradeId}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int gradeId)
        {
            _logger.LogInformation("Getting list of grade by ID:{id}", gradeId);
            var result = await _gradeService.GetGradeAsync(gradeId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Grade
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] GradeVm gradeVm)
        {
            var repeatedData = await _gradeService.GetNotRepeatedDataForGrade(gradeVm.GradeName, gradeVm.Description);
            if (repeatedData != null)
            {
                return BadRequest("Grade is already exist");
            }
            _logger.LogInformation("Add new data for grades");
            var Data = _mapper.Map<GradeVm, Grade>(gradeVm);
            var result = await _gradeService.CreateGradeAsync(Data);
            return Ok(result);
        }

        // Put Grade {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] GradeVm gradeVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var repeatedData = await _gradeService.GetNotRepeatedDataForGrade(gradeVm.GradeName, gradeVm.Description);
            if (repeatedData != null)
            {
                return BadRequest("Grade is already exist");
            }
            var data = _mapper.Map<GradeVm, Grade>(gradeVm);
            var result = await _gradeService.UpdateGradeAsync(id, data);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        // Delete Grade {id}
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
            var existingGrade = await _gradeService.GetGradeAsync(id);
            if (existingGrade != null)
            {
                var result = await _gradeService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Grade Not Found");
        }

        [MapToApiVersion("1.0")]
        [Route("gradedetails/{gradeId}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetGradeDetails(int gradeId)
        {
            _logger.LogInformation("Getting list of grade by ID:{id}", gradeId);
            var result = await _gradeService.GetGradeCourseAsync(gradeId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
