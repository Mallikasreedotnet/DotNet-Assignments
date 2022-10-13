using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Infrastructure.Specs;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("classroom")]
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
        [Authorize(Roles = "teacher")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all classrooms");
            var result = await _classroomService.GetClassroomAsync();
            return Ok(result);
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
        [Authorize(Roles = "teacher")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ClassroomVm classroomVm)
        {
            var availableTeacher = await _classroomService.GetTeacherwithGrade(classroomVm.GradeId, classroomVm.TeacherId, classroomVm.Section);
            if (availableTeacher != null)
            {
                return BadRequest("Teacher is already exist");
            }
            _logger.LogInformation("Add new data for Classrooms");
            var Data = _mapper.Map<ClassroomVm, Classroom>(classroomVm);
            var result = await _classroomService.CreateClassroomAsync(Data);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        // Put Classroom {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ClassroomVm classroomVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var availableRepeationData = await _classroomService.GetTeacherwithGrade(classroomVm.GradeId, classroomVm.TeacherId, classroomVm.Section);
            if (availableRepeationData != null)
            {
                return BadRequest("Teacher is already exist");
            }
            var data = _mapper.Map<ClassroomVm, Classroom>(classroomVm);
            var result = await _classroomService.UpdateClassroomAsync(id, data);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Delete Classroom {id}
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
            var existingData = await _classroomService.GetClassroomAsync(id);
            if (existingData != null)
            {
                var result = await _classroomService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Classroom not found");
        }


        [MapToApiVersion("1.0")]
        [Route("classroomwithstudentcount/{classroomId}")]
        [Authorize(Roles = "teacher")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetClassroomWithStudentCount(int classroomId)
        {
            _logger.LogInformation("Getting list of classroomDetails by ID:{id}", classroomId);
            var result = await _classroomService.GetClassroomWithStudentByCountAsync(classroomId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [MapToApiVersion("1.0")]
        [Route("classroomwithstudentdetails/{classroomId}")]
        [Authorize(Roles = "teacher")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetClassroomWithStudents(int classroomId)
        {
            _logger.LogInformation("Getting list of classroomDetails by ID:{id}", classroomId);
            var result = await _classroomService.GetClassroomWithStudentDetails(classroomId);

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
