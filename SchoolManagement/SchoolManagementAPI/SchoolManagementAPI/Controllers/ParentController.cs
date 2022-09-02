using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Entities;
using SchoolManagementAPI.ViewModel;
using System.Net;

namespace SchoolManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParentController : Controller
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

        [HttpGet("GetParent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        // GET/api/Parent
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all parents");
            var result =  await _parent.GetParentAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        // GET/api/Parent/int
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of parent by ID:{id}",id);
            var result = await _parent.GetParentAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ParentVm parentVm)
        {
            var Data=_mapper.Map<ParentVm,Parent>(parentVm);
            return Ok(await _parent.CreateParentAsync(Data));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ParentVm parentVm)
        {
            var Data = _mapper.Map<ParentVm, Parent>(parentVm);
            return Ok(await _parent.UpdateAsync(id, Data));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _parent.DeleteAsync(id);
        }
    }
}
