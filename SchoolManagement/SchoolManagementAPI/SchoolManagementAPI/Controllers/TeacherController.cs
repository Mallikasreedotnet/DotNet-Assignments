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
    public class TeacherController:Controller
    {
        private readonly ITeacherRepository _teacher;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacher, IMapper mapper)
        {
            _teacher = teacher;
            _mapper = mapper;
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
            var teacherData=_mapper.Map<TeacherVm,Teacher>(teacherVm);
            return Ok(await _teacher.CreateTeacherAsync(teacherData)); ;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeacherVm teacherVm)
        {
            var teacherData=_mapper.Map<TeacherVm,Teacher>(teacherVm);
            return Ok(await _teacher.UpdateAsync(id, teacherData));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _teacher.DeleteAsync(id);
        }

    }
}
