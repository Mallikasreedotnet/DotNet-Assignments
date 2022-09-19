using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {

    }
}
