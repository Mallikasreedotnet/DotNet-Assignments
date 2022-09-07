using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Repository.EntityFramework;
using SchoolManagementAPI.Infrastructure.Specs;
using SchoolManagementAPI.ViewModel;

namespace SchoolManagementAPI.Controllers
{
    public class ExamController : ApiControllerBase
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ExamController(IExamRepository examRepository, ILogger<ExamController> logger, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Exam
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all Exams");
            var result = await _examRepository.GetExamAsync();
            //if (!result.Any())
            //    return NotFound();
            return Ok(result);
        }

        // Get Exam {id}
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of Exam by ID:{id}", id);
            var result = await _examRepository.GetExamAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post Exam
        [Route("")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ExamVm examVm)
        {
            _logger.LogInformation("Add new data for Exam");
            var Data = _mapper.Map<ExamVm, Exam>(examVm);
            var result = await _examRepository.CreateExamAsync(Data);
            return Ok(result);
        }

        // Put Exam {id}
        [Route("{id}")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ExamVm examVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var data = _mapper.Map<ExamVm, Exam>(examVm);
            var result = await _examRepository.UpdateExamAsync(id, data);
            if (result is null)
            {
                return NotFound();
                // return NoContent();
            }
            return Ok(result);
        }

        // Delete Exam {id}
        [Route("{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var result = await _examRepository.DeleteAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }


        [Route("type")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetExamType()
        {
            _logger.LogInformation("Getting list of all ExamTpye");
            var result = await _examRepository.GetExamTypeAsync(); ;
            //if (!result.Any())
            //    return NotFound();
            return Ok(result);
        }

        // Get ExamType {id}
        [HttpGet]
        [Route("type/{id}")]       
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetExamType(int id)
        {
            _logger.LogInformation("Getting list of ExamTpye by ID:{id}", id);
            var result = await _examRepository.GetExamTypeAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Post ExamType
        [Route("type")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ExamTypeVm examTypeVm)
        {
            _logger.LogInformation("Add new data for courses");
            var Data = _mapper.Map<ExamTypeVm, ExamType>(examTypeVm);
            var result = await _examRepository.CreateExamTypeAsync(Data);
            return Ok(result);
        }

        //// Put ExamType {id}
        [HttpPut]
        [Route("type/{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ExamTypeVm examTypeVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var data = _mapper.Map<ExamTypeVm, ExamType>(examTypeVm);
            var result = await _examRepository.UpdateExamTypeAsync(id, data);
            if (result is null)
            {
                return NotFound();
                // return NoContent();
            }
            return Ok(result);
        }


        // Delete ExamType {id}
        [Route("type/{id}")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> DeleteExamType(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var result = await _examRepository.DeleteExamTypeAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
