using JWT.Authentication.Server.Core.Contract.Infrastructure.Repositories;
using JWT.Authentication.Server.Core.Entities;
using JWT.Authentication.Server.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Authentication.Server.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthStudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IConfiguration _configuration;
       
        public AuthStudentController(IStudentRepository student,IConfiguration configuration)
        {
            _studentRepository = student;
            _configuration = configuration;
        }
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody]StudentVm studentVm)
        {
            Student student = new()
            {
                Fname = studentVm.Fname,
                Email = studentVm.Email,
                Password = studentVm.Password,
                LastLoginDate = studentVm.LastLoginDate,
                DateOfJoin = studentVm.DateOfJoin,
                LastLoginIp = studentVm.LastLoginIp,
                Lname = studentVm.Lname,
                Dob = studentVm.Dob,
                Mobile = studentVm.Mobile,
                ParentId = studentVm.ParentId,
                Phone = studentVm.Phone,    
                Status = studentVm.Status,
                
                //PasswordSalt = String.Empty
            };
            await _studentRepository.RegisterStudent(student);
            return Ok(true);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginVm loginVm)
        {
            var isAuthenticationStudent=await _studentRepository.ValidateStudent(loginVm.Email,loginVm.Password);
            if (!isAuthenticationStudent)
                return BadRequest("Invaild username and password");
            return Ok("Logged in successfully");
        }
    }
}
