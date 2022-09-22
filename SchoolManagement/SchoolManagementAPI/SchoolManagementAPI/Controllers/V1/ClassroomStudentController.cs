using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Services;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class ClassroomStudentController : ApiControllerBase
    {
        private readonly IClassroomStudentService _classroomStudentService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ClassroomStudentController(IClassroomStudentService classroomStudentService, ILogger<ClassroomStudentController> logger, IMapper mapper)
        {
            _classroomStudentService = classroomStudentService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get ClassroomStudents
        [MapToApiVersion("1.0")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all classroomStudents");
            var result = await _classroomStudentService.GetClassroomStudentAsync();
            return Ok(result);
        }

        // Get ClassroomStudents
        [MapToApiVersion("1.1")]
        [HttpGet("")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<string> GetDataFromNewVersion()
        {
            _logger.LogInformation("Getting sample text from version 2 API");
            return Ok("Sample Text from V1.1 API");
        }

        // Get ClassroomStudent {id}
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of classroomStudent by ID:{id}", id);
            var result = await _classroomStudentService.GetClassroomStudentAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post ClassroomStudent
        [MapToApiVersion("1.0")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ClassroomStudentVm classroomStudentVm)
        {
            var notRepeatedData = await _classroomStudentService.GetNotRepeatedData(classroomStudentVm.ClassroomId, classroomStudentVm.StudentId);
            if (notRepeatedData != null)
            {
              return  BadRequest("ClassroomStudent is already exist");
            }
            _logger.LogInformation("Add new data for ClassroomStudent");
            var Data = _mapper.Map<ClassroomStudentVm, ClassroomStudent>(classroomStudentVm);
            var result = await _classroomStudentService.CreateClassroomStudentAsync(Data);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        // Put ClassroomStudent {id}
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ClassroomStudentVm classroomStudentVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var notRepeatedData = await _classroomStudentService.GetNotRepeatedData(classroomStudentVm.ClassroomId, classroomStudentVm.StudentId);
            if (notRepeatedData != null)
            {
                return BadRequest("ClassroomStudent is already exist");
            }
            var data = _mapper.Map<ClassroomStudentVm, ClassroomStudent>(classroomStudentVm);
            var result = await _classroomStudentService.UpdateClassroomStudentAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Delete ClassroomStudent {id}
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var existingData= await _classroomStudentService.GetClassroomStudentAsync(id);
            if (existingData != null)
            {
                var result = await _classroomStudentService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("ClassroomStudent not found");
        }

    }
}
