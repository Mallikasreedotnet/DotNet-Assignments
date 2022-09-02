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
    public class StudentController : Controller
    {
        private readonly IStudentRepository _student;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
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
         
            var studentData=_mapper.Map<StudentVm,Student>(studentVm);
            return Ok(await _student.CreateStudentAsync(studentData)); ;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentVm studentVm)
        {
            var studentData=_mapper.Map<StudentVm,Student>(studentVm);
            return Ok(await _student.UpdateAsync(id, studentData));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _student.DeleteAsync(id);
        }

    }
}
