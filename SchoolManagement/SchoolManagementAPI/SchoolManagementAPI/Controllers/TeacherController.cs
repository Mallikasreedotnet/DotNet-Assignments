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
    public class TeacherController:Controller
    {
        private readonly ITeacher _teacher;
        public TeacherController()
        {
           _teacher = new TeacherRepository(new SchoolManagementDbContext());
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _teacher.GetTeacherAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _teacher.GetTeacherAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TeacherVm teacherVm)
        {
            var teacher=new Teacher { Email = teacherVm.Email, Password=teacherVm.Password, Fname=teacherVm.Fname, Lname=teacherVm.Lname, 
                Dob=teacherVm.Dob,Phone=teacherVm.Phone,Mobile=teacherVm.Mobile,Status=teacherVm.Status,
                LastLoginDate=teacherVm.LastLoginDate, LastLoginIp=teacherVm.LastLoginIp };
            return Ok(await _teacher.CreateTeacherAsync(teacher)); ;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeacherVm teacherVm)
        {
            var teacher=new Teacher {
                TeacherId=teacherVm.TeacherId,
                Email = teacherVm.Email,
                Password = teacherVm.Password,
                Fname = teacherVm.Fname,
                Lname = teacherVm.Lname,
                Dob = teacherVm.Dob,
                Phone = teacherVm.Phone,
                Mobile = teacherVm.Mobile,
                Status = teacherVm.Status,
                LastLoginDate = teacherVm.LastLoginDate,
                LastLoginIp = teacherVm.LastLoginIp
            };
            return Ok(await _teacher.UpdateAsync(id, teacher));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _teacher.DeleteAsync(id);
        }

    }
}
