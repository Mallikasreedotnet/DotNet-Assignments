using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    public class GradeController : ApiControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GradeController(IGradeRepository gradeRepository, IMapper mapper, ILogger<GradeController> logger)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Grades
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all grades");
            var result = await _gradeRepository.GetGradeAsync();
            return Ok(result);
        }
    }
}
