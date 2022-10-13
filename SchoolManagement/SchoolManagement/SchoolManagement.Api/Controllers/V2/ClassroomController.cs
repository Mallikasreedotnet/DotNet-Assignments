using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;

namespace SchoolManagement.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    public class ClassroomController : ApiControllerBase
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public ClassroomController(IClassroomRepository classroomRepository, ILogger<ClassroomController> logger, IMapper mapper)
        {
            _classroomRepository = classroomRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // Get Classroom {id}
        [MapToApiVersion("2.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of Classroom by ID:{id}", id);
            var result = await _classroomRepository.GetClassroomAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
