using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V2
{
    [ApiVersion("2.0")]
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
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all students");
            var result = await _student.GetStudentAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }
    }
}
