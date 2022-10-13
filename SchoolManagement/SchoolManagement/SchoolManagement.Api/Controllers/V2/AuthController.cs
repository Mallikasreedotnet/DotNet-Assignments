using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Infrastructure.Specs;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;

namespace SchoolManagement.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AuthController : ApiControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IAuthService _authService;
        private readonly IStudentRepository _studentRepository;
        private readonly IParentRepository _parentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IStudentService student, ITeacherRepository teacherRepository, IAuthService authService, IConfiguration config, IStudentRepository studentRepository, IMapper mapper, IParentRepository parentRepository)
        {
            _teacherRepository = teacherRepository;
            _parentRepository = parentRepository;
            _studentService = student;
            _authService = authService;
            _config = config;
            _studentRepository = studentRepository;
            _mapper = mapper;

        }
        UserDto userData;
        [Route("login")]
        [HttpPost]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Login([FromBody] LoginVm loginVm)
        {
           
            userData = await _parentRepository.GetUserDetails(loginVm.Email,loginVm.User);

            //var data = await _parentRepository.GetUserDetails(loginVm.Email);
            if (userData is null)
                return BadRequest("Invalid Email address or Password");
            var tupleData = _authService.GeneratePassword(loginVm.Password, userData.PasswordSalt);
            if (tupleData.password == userData.Password)
            {
                var token = _authService.GenerateToken(userData, loginVm.User);
                return Ok(token);
            }
            return BadRequest("Invalid Email address or Password");
        }
    }
}
