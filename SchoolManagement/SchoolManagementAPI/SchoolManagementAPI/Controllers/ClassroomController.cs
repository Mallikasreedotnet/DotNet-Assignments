using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    public class ClassroomController : ApiControllerBase
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ClassroomController(IClassroomRepository classroomRepository, ILogger<ClassroomController> logger, IMapper mapper)
        {
            _classroomRepository = classroomRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Classrooms
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all classrooms");
            var result = await _classroomRepository.GetClassroomAsync();
            //if (!result.Any())
            //    return NotFound();
            return Ok(result);
        }

        // Get Classroom {id}
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of classroom by ID:{id}", id);
            var result = await _classroomRepository.GetClassroomAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Classroom
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ClassroomVm classroomVm)
        {
            _logger.LogInformation("Add new data for courses");
            var Data = _mapper.Map<ClassroomVm, Classroom>(classroomVm);
            var result = await _classroomRepository.CreateClassroomAsync(Data);
            return Ok(result);
        }

        // Put Classroom {id}
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
            var result = await _classroomRepository.UpdateClassroomAsync(id, data);
            if (result is null)
            {
                return NotFound();
                // return NoContent();
            }
            return Ok(result);
        }

        // Delete Classroom {id}
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
            var result = await _classroomRepository.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }


    }
}
