using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParentController : Controller
    {
        private readonly IParentRepository _parent;
        private readonly IMapper _mapper;
        public ParentController(IParentRepository parent, IMapper mapper)
        {
            _parent = parent;
            _mapper = mapper;
        }

        [HttpGet("GetParent")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _parent.GetParentAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _parent.GetParentAsync(id));
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
