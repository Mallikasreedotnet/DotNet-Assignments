using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{

    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TeacherController: ApiControllerBase
    {
        private readonly ITeacherRepository _teacher;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TeacherController(ITeacherRepository teacher, IMapper mapper, ILogger<TeacherController> logger)
        {
            _teacher = teacher;
            _mapper = mapper;
            _logger = logger;   
        }

        // Get Teacher
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all teachers");
            var result = await _teacher.GetTeacherAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        // Get Teacher/{id}
        [Route("controller/{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of teacher by ID:{id}", id);
            var result = await _teacher.GetTeacherAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Post Teacher
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] TeacherVm teacherVm)
        {
            _logger.LogInformation("Add new data for teacher");
            var teacherData=_mapper.Map<TeacherVm,Teacher>(teacherVm);
            var result = await _teacher.CreateTeacherAsync(teacherData);
            return Ok(result);
            // return Ok(await _teacher.CreateTeacherAsync(teacherData)); ;
        }

        // Put Teacher/{id}
        [Route("controller/{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] TeacherVm teacherVm)
        {
            if (id <= 0 )
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var teacherData=_mapper.Map<TeacherVm,Teacher>(teacherVm);
            var result = await _teacher.UpdateAsync(id, teacherData);
            if (result is null)
                return NotFound();
            return Ok(result);

        }

        // Delete Teacher/{id}
        [Route("controller/{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var result = await _teacher.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

    }
}
