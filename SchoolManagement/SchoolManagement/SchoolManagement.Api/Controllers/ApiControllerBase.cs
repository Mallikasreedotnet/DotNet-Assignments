using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Api.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {

    }
}
