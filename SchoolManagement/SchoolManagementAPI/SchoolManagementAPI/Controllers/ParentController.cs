using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Infrastructure.Models;
using SchoolManagement.Infrastructure.Repository.EntityFramework;

namespace SchoolManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParentController : Controller
    {
        private readonly IParent _parent;
        public ParentController()
        {
            _parent = new ParentRepository(new SchoolManagementContext());
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _parent.GetParentAsync());
        }
    }
}
