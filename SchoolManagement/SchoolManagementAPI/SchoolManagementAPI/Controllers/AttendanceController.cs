using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    public class AttendanceController : ApiControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AttendanceController(IAttendanceRepository classroomRepository, ILogger<AttendanceController> logger, IMapper mapper)
        {
            _attendanceRepository = classroomRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Attendances
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all attendances");
            var result = await _attendanceRepository.GetAttendanceAsync();
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
            _logger.LogInformation("Getting list of Attendance by ID:{id}", id);
            var result = await _attendanceRepository.GetAttendanceAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Attendance
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] AttendanceVm attendanceVm)
        {
            _logger.LogInformation("Add new data for attendance");
            var Data = _mapper.Map<AttendanceVm, Attendance>(attendanceVm);
            var result = await _attendanceRepository.CreateAttendanceAsync(Data);
            return Ok(result);
        }

        // Put Attendance {id}
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] AttendanceVm attendanceVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var data = _mapper.Map<AttendanceVm, Attendance>(attendanceVm);
            var result = await _attendanceRepository.UpdateAttendanceAsync(id, data);
            if (result is null)
            {
                return NotFound();
                // return NoContent();
            }
            return Ok(result);
        }

        // Delete Attendance {id}
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
            var result = await _attendanceRepository.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }



    }
}
