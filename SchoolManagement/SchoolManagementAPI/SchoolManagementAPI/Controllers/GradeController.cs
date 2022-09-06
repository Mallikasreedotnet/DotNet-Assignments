using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    public class GradeController : ApiControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        public GradeController(IGradeRepository gradeRepository,IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }
        [HttpGet]
       // [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
             var result=await _gradeRepository.GetGradeAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _gradeRepository.GetGradeAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GradeVm gradeVm)
        {
            var Data = _mapper.Map<GradeVm, Grade>(gradeVm);
            var result = await _gradeRepository.CreateGradeAsync(Data);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] GradeVm gradeVm)
        {
            var data = _mapper.Map<GradeVm, Grade>(gradeVm);
            var result = await _gradeRepository.UpdateGradeAsync(id,data);
            if (result is null)
            {
                return NotFound();
                // return NoContent();
            }
            return Ok(result);
        }
    }
}
