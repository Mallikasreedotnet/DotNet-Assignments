using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
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


        // Get Grades
        [MapToApiVersion("1.1")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<string> GetDataFromNewVersion()
        {
            _logger.LogInformation("Getting sample text from version 2 API");
            return Ok("Sample Text from V1.1 API");
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
            var data = _mapper.Map<GradeVm, Grade>(gradeVm);
            var result = await _gradeService.UpdateGradeAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
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
            var result = await _gradeService.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [MapToApiVersion("1.0")]
        [Route("api/{gradeId}")]
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
