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
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        public StudentController()
        {
            _student = new StudentRepository(new SchoolManagementDbContext());
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _student.GetStudentAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _student.GetStudentAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentVm studentVm)
        {
            var student = new Student
            {
                Email = studentVm.Email,
                Password = studentVm.Password,
                Fname = studentVm.Fname,
                Lname = studentVm.Lname,
                Dob = studentVm.Dob,
                Phone = studentVm.Phone,
                Mobile = studentVm.Mobile,
                Status = studentVm.Status,
                LastLoginDate = studentVm.LastLoginDate,
                LastLoginIp = studentVm.LastLoginIp,
                DateOfJoin = studentVm.DateOfJoin
            };
            return Ok(await _student.CreateStudentAsync(student)); ;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentVm studentVm)
        {
            var student = new Student
            {
                StudentId = studentVm.StudentId,
                Email = studentVm.Email,
                Password = studentVm.Password,
                Fname = studentVm.Fname,
                Lname = studentVm.Lname,
                Dob = studentVm.Dob,
                Phone = studentVm.Phone,
                Mobile = studentVm.Mobile,
                Status = studentVm.Status,
                LastLoginDate = studentVm.LastLoginDate,
                LastLoginIp = studentVm.LastLoginIp,
                DateOfJoin = studentVm.DateOfJoin
            };
            return Ok(await _student.UpdateAsync(id, student));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _student.DeleteAsync(id);
        }

    }
}
