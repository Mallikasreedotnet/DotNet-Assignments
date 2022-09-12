using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V2
{
    [ApiVersion("2.0")]
   
    public class AttendanceController : ApiControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILogger<AttendanceController> _logger;
        private readonly IMapper _mapper;
        public AttendanceController(IAttendanceRepository classroomRepository, ILogger<AttendanceController> logger, IMapper mapper)
        {
            _attendanceRepository = classroomRepository;
            _logger = logger;
            _mapper = mapper;   
        }

        // Get Attendances
        [MapToApiVersion("2.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all attendances");
            var result = await _attendanceRepository.GetAttendanceAsync();
            return Ok(result);
        }

        // Get Attendance {id}
        [MapToApiVersion("2.0")]
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

    }
}
