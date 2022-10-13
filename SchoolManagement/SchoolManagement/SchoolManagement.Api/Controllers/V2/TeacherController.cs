using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;

namespace SchoolManagement.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TeacherController : ApiControllerBase
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
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all teachers");
            var result = await _teacher.GetTeacherAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }
    }
}
