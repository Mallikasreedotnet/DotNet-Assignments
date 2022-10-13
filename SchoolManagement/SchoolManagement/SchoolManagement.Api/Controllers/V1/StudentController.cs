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
    [Route("student")]
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StudentController(IStudentService studentService, IAuthService authService, IStudentRepository studentRepository, IMapper mapper, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Students
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all students");
            var result = await _studentService.GetStudentAsync();
            return Ok(result);
        }


        // Get Student/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of student by ID:{id}", id);
            var result = await _studentService.GetStudentAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Post Student
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] StudentVm studentVm)
        {
            _logger.LogInformation("Add new data for students");
            var studentData = _mapper.Map<StudentVm, Student>(studentVm);
            var tupleData = _authService.GeneratePassword(studentData.Password);
            studentData.Password = tupleData.password;
            studentData.PasswordSalt = tupleData.passwordSalt;
            var result = await _studentService.CreateStudentAsync(studentData);
            return Ok(result);
        }

        // Put Student/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] StudentVm studentVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var studentData = _mapper.Map<StudentVm, Student>(studentVm);
            var result = await _studentService.UpdateAsync(id, studentData);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Delete Student/{id}
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
            var existingData = await _studentService.GetStudentAsync(id);
            if (existingData != null)
            {
                var result = await _studentService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("student not found");
        }

        // Get Student id with class id
        [MapToApiVersion("1.0")]
        [Route("studentwithclassroomdetails/{studentId}")]
        [Authorize(Roles = "teacher,parent")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetStudentAndClassId(int studentId)
        {
            var result = await _studentService.GetStudentsWithClass(studentId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
