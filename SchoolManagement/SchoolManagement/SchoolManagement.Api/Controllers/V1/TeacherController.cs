using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("teacher")]
    public class TeacherController : ApiControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TeacherController(ITeacherService teacherService, IMapper mapper, IAuthService authService, ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Teachers
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all teachers");
            var result = await _teacherService.GetTeacherAsync();
            return Ok(result);
        }


        // Get Teacher{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of teacher by ID:{id}", id);
            var result = await _teacherService.GetTeacherAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }


        // Post Teacher
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] TeacherVm teacherVm)
        {
            _logger.LogInformation("Add new data for teacher");
            var teacherData = _mapper.Map<TeacherVm, Teacher>(teacherVm);
            var tupleData = _authService.GeneratePassword(teacherData.Password);
            teacherData.Password = tupleData.password;
            teacherData.PasswordSalt = tupleData.passwordSalt;
            var result = await _teacherService.CreateTeacherAsync(teacherData);
            return Ok(result);
        }

        // Put Teacher/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] TeacherVm teacherVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var teacherData = _mapper.Map<TeacherVm, Teacher>(teacherVm);
            var result = await _teacherService.UpdateAsync(id, teacherData);
            if (result is null)
                return NotFound();
            return Ok(result);

        }

        // Delete Teacher/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var existingData = await _teacherService.GetTeacherAsync(id);
            if (existingData != null)
            {
                var result = await _teacherService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("teacher not found");
        }


        // Get Teacher id with classroom
        [MapToApiVersion("1.0")]
        [Route("teacherclassroomdetails/{teacherId}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetTeacherAndClassroom(int teacherId)
        {
            var result = await _teacherService.GetTeacherWithClass(teacherId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
