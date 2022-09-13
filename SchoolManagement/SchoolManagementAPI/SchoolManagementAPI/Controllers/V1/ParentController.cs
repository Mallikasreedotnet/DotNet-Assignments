using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ParentController : ApiControllerBase
    {
        private readonly IParentService _parentService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ParentController(IParentService parentService, ILogger<ParentController> logger, IMapper mapper)
        {
            _parentService = parentService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET Parent
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all parents");
            var result =  await _parentService.GetParentAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }


        // Get Parents
        [MapToApiVersion("1.1")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<string> GetDataFromNewVersion()
        {
            _logger.LogInformation("Getting sample text from version 2 API");
            return Ok("Sample Text from V1.1 API");
        }

        // Get Parent/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of parent by ID:{id}",id);
            var result = await _parentService.GetParentAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Get Parent with student
        [MapToApiVersion("1.0")]
        [Route("/ParentClass{parentId}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetParentAndStudent(int parentId)
        {
            var result = await _parentService.GetParentWithStudent(parentId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Post Parent
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ParentVm parentVm)
        {
            _logger.LogInformation("Add new data for parents");
            var Data=_mapper.Map<ParentVm,Parent>(parentVm);
            var result = await _parentService.CreateParentAsync(Data);
            return Ok(result);
        
        }

        // Put Parent/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ParentVm parentVm)
        {
            if (id <= 0 )
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var Data = _mapper.Map<ParentVm, Parent>(parentVm);
            var result = await _parentService.UpdateParentAsync(id,Data);
            if (result is null)
            {
                return NotFound();
               // return NoContent();
            }
            return Ok(result);
        }

        // Delete Parent/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions),nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if(id<=0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)),"Id field can't be {id}",id);
                return BadRequest();
            }
            var result =  await _parentService.DeleteAsync(id);
            if(result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
