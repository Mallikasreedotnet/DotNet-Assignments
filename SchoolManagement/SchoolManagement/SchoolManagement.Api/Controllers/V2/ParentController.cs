using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;

namespace SchoolManagement.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ParentController : ApiControllerBase
    {
        private readonly IParentRepository _parent;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ParentController(IParentRepository parent, ILogger<ParentController> logger, IMapper mapper)
        {
            _parent = parent;
            _mapper = mapper;
            _logger = logger;
        }

        // GET Parent
        [MapToApiVersion("2.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(string? Fname = null)
        {
            _logger.LogInformation("Getting list of all parents");
            var result = await _parent.GetParentAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }
    }
}
