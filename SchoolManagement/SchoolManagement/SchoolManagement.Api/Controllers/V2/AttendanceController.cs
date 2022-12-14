using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;

namespace SchoolManagement.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("attendance")]
    public class AttendanceController : ApiControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILogger<AttendanceController> _logger;
        private readonly IMapper _mapper;
        public AttendanceController(IAttendanceRepository attendanceRepository, ILogger<AttendanceController> logger, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _logger = logger;
            _mapper = mapper;
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
