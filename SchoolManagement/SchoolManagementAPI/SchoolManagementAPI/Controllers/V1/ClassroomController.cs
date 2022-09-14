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
    public class ClassroomController : ApiControllerBase
    {
        private readonly IClassroomService _classroomService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ClassroomController(IClassroomService classroomService, ILogger<ClassroomController> logger, IMapper mapper)
        {
            _classroomService = classroomService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Classrooms
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all classrooms");
            var result = await _classroomService.GetClassroomAsync();
            return Ok(result);
        }

        // Get Classrooms
        [MapToApiVersion("1.1")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<string> GetDataFromNewVersion()
        {
            _logger.LogInformation("Getting sample text from version 2 API");
            return Ok("Sample Text from V1.1 API");
        }

        // Get Classroom {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of classroom by ID:{id}", id);
            var result = await _classroomService.GetClassroomAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Classroom
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ClassroomVm classroomVm)
        {
            _logger.LogInformation("Add new data for courses");
            var Data = _mapper.Map<ClassroomVm, Classroom>(classroomVm);
            var result = await _classroomService.CreateClassroomAsync(Data);
            return Ok(result);
        }

        // Put Classroom {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ClassroomVm classroomVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var data = _mapper.Map<ClassroomVm, Classroom>(classroomVm);
            var result = await _classroomService.UpdateClassroomAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Delete Classroom {id}
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
            var result = await _classroomService.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }


    }
}
