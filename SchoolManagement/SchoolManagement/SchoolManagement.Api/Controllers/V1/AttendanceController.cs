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
    //[Authorize]
    [Route("attendance")]
    public class AttendanceController : ApiControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AttendanceController(IAttendanceService attendanceService, ILogger<AttendanceController> logger, IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Attendances
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all attendances");
            var result = await _attendanceService.GetAttendanceAsync();
            return Ok(result);
        }


        // Get Attendance {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of Attendance by ID:{id}", id);
            var result = await _attendanceService.GetAttendanceAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Attendance
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] AttendanceVm attendanceVm)
        {
            _logger.LogInformation("Add new data for attendance");
            var data = _mapper.Map<AttendanceVm, Attendance>(attendanceVm);
            var result = await _attendanceService.CreateAttendanceAsync(data);
            return Ok(result);
        }

        // Put Attendance {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
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
            var result = await _attendanceService.UpdateAttendanceAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Delete Attendance {id}
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
            var existingData = await _attendanceService.GetAttendanceByIdAsync(id);
            if (existingData != null)
            {
                var result = await _attendanceService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Attendance not found");
        }

        [MapToApiVersion("1.0")]
        [Route("studentwithattendance/{studentId}")]
        [Authorize(Roles = "teacher,parent")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetStudentAttendanceDetails(int studentId)
        {
            _logger.LogInformation("Getting list of student by ID:{id}", studentId);
            var result = await _attendanceService.GetStudentAttendanceAsync(studentId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
