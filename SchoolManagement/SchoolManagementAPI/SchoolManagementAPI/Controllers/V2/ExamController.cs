using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    public class ExamController : ApiControllerBase
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ExamController(IExamRepository examRepository, ILogger<ExamController> logger, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Exam
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all Exams");
            var result = await _examRepository.GetExamAsync();
            return Ok(result);
        }
    }
}
