using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V2
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

        // Get Classrooms
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all classrooms");
            var result = await _classroomRepository.GetClassroomAsync();
            return Ok(result);
        }
    }
}
