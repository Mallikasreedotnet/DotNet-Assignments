using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class GradeController : ApiControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GradeController(IGradeRepository gradeRepository, IMapper mapper, ILogger<GradeController> logger)
        {
            _gradeRepository = gradeRepository;
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
            var result = await _gradeRepository.GetGradeAsync();
            //if (!result.Any())
            //    return NotFound();
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
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of grade by ID:{id}", id);
            var result = await _gradeRepository.GetGradeAsync(id);
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
            var result = await _gradeRepository.CreateGradeAsync(Data);
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
            var result = await _gradeRepository.UpdateGradeAsync(id, data);
            if (result is null)
            {
                return NotFound();
                // return NoContent();
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
            var result = await _gradeRepository.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
