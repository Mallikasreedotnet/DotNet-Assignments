using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParentController : Controller
    {
        private readonly IParent _parent;
        public ParentController()
        {
            _parent = new ParentRepository(new SchoolManagementDbContext());
        }

        [HttpGet]
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
        public async Task<ActionResult> AddParent([FromBody] ParentVm parentVm)
        {
            
            var parent=new Parent() 
            {
                Email=parentVm.Email,
                Password=parentVm.Password, 
                Fname=parentVm.Fname, 
                Lname=parentVm.Lname, 
                Dob=parentVm.Dob,
                Phone=parentVm.Phone,
                Mobile=parentVm.Mobile,
                Status=parentVm.Status,
                LastLoginDate=parentVm.LastLoginDate, 
                LastLoginIp=parentVm.LastLoginIp
            };
            return Ok(await _parent.CreateParentAsync(parent));

        }
    }
}
