using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentRepository _student;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StudentController(IStudentRepository student, IMapper mapper, ILogger<StudentController> logger)
        {
            _student = student;
            _mapper = mapper;
            _logger = logger;   
        }

        // Get Student
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all students");
            var result = await _student.GetStudentAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        // Get Student/{id}
        [Route("controller/{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
                _logger.LogInformation("Getting list of student by ID:{id}", id);
                var result = await _student.GetStudentAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            
        }

        // Post Student
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] StudentVm studentVm)
        {
            _logger.LogInformation("Add new data for students");
            var studentData=_mapper.Map<StudentVm,Student>(studentVm);
            var result = await _student.CreateStudentAsync(studentData);
            return Ok(result);
           // return Ok(await _student.CreateStudentAsync(studentData)); 
        }

        // Put Student/{id}
        [Route("controller/{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] StudentVm studentVm)
        {
            if (id <= 0 || id != studentVm.Student_id)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var studentData=_mapper.Map<StudentVm,Student>(studentVm);
            var result = await _student.UpdateAsync(id, studentData);
            if (result is null)
                return NotFound();
            return NoContent();
           
        }

        // Delete Student/{id}
        [Route("controller/{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var result = await _student.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return NoContent();
        }

    }
}
