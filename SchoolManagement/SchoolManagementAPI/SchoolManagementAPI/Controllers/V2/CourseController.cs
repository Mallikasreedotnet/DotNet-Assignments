using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    public class CourseController : ApiControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public CourseController(ICourseRepository courseRepository, ILogger<CourseController> logger, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Courses
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(string? courseName)
        {
            _logger.LogInformation("Getting list of all courses by using courseName");
            var result = await _courseRepository.GetCourseWithCourseName(courseName);
            return Ok(result);
        }
    }
}
