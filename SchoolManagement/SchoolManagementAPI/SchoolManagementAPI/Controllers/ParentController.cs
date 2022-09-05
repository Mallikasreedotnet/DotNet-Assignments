using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Entities;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;
using System.Net;

namespace SchoolManagementAPI.Controllers
{
    
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
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all parents");
            var result =  await _parent.GetParentAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        // Get Parent/{id}
        [Route("controller/{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of parent by ID:{id}",id);
            var result = await _parent.GetParentAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Post Parent
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ParentVm parentVm)
        {
            _logger.LogInformation("Add new data for parents");
            var Data=_mapper.Map<ParentVm,Parent>(parentVm);
            var result = await _parent.CreateParentAsync(Data);
            return Ok(result);
           // return Ok(await _parent.CreateParentAsync(Data));
        }

        // Put Parent/{id}
        [Route("controller/{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
       
        public async Task<ActionResult> Put(int id, [FromBody] ParentVm parentVm)
        {
            if (id <= 0 || id != parentVm.Parent_id)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var Data = _mapper.Map<ParentVm, Parent>(parentVm);
            var result = await _parent.UpdateAsync(id, Data);
            if (result is null) 
            return NotFound();
            return NoContent();
        }

        // Delete Parent/{id}
        [Route("controller/{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions),nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if(id<=0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)),"Id field can't be {id}",id);
                return BadRequest();
            }
            var result =  await _parent.DeleteAsync(id);
            if(result is null)
                return NotFound();
            return NoContent();
        }
    }
}
