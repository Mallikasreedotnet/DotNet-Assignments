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
    [Route("course")]
    public class CourseController : ApiControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, ILogger<CourseController> logger, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Courses
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all courses");
            var result = await _courseService.GetCourseAsync();
            return Ok(result);
        }


        // Get Course {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of course by ID:{id}", id);
            var result = await _courseService.GetCourseAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Course
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] CourseVm courseVm)
        {
            var available = await _courseService.GetCourseName(courseVm.CourseName, courseVm.GradeId);
            if (available != null && available.CourseName == courseVm.CourseName && available.GradeId == courseVm.GradeId)
            {
                return BadRequest("Course already exist");
            }
            _logger.LogInformation("Add new data for courses");
            var Data = _mapper.Map<CourseVm, Course>(courseVm);
            var result = await _courseService.CreateCourseAsync(Data);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }


        // Put Course {id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] CourseVm courseVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var available = await _courseService.GetCourseName(courseVm.CourseName, courseVm.GradeId);
            if (available != null)
            {
                return BadRequest("Course already exist");
            }
            var data = _mapper.Map<CourseVm, Course>(courseVm);
            var result = await _courseService.UpdateCourseAsync(id, data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // Delete Course {id}
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
            var existingData = await _courseService.GetCourseAsync(id);
            if (existingData != null)
            {
                var result = await _courseService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("Course not found");
        }

    }
}
