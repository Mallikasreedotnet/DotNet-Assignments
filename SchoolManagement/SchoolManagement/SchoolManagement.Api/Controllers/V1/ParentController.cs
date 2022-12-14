using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Infrastructure.Specs;
using SchoolManagement.Api.ViewModel;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("parent")]
    public class ParentController : ApiControllerBase
    {
        private readonly IParentService _parentService;
        private readonly IAuthService _authService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ParentController(IParentService parentService, IAuthService authService, ILogger<ParentController> logger, IMapper mapper)
        {
            _parentService = parentService;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        // Get Parents
        [MapToApiVersion("1.0")]
        [Route("")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting list of all Parents");
            var result = await _parentService.GetParentAsync();
            return Ok(result);
        }


        // Get Parent/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Getting list of parent by ID:{id}", id);
            var result = await _parentService.GetParentAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        // Post Parent
        [MapToApiVersion("1.0")]
        [Route("")]
        [Authorize(Roles = "teacher")]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> Post([FromBody] ParentVm parentVm)
        {
            _logger.LogInformation("Add new data for parents");
            var parentData = _mapper.Map<ParentVm, Parent>(parentVm);
            var tupleData = _authService.GeneratePassword(parentData.Password);
            parentData.Password = tupleData.password;
            parentData.PasswordSalt = tupleData.passwordSalt;
            var result = await _parentService.CreateParentAsync(parentData);
            return Ok(result);
        }

        // Put Parent/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<ActionResult> Put(int id, [FromBody] ParentVm parentVm)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
                return BadRequest();
            }
            var Data = _mapper.Map<ParentVm, Parent>(parentVm);
            var result = await _parentService.UpdateParentAsync(id, Data);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Delete Parent/{id}
        [MapToApiVersion("1.0")]
        [Route("{id}")]
        [Authorize(Roles = "teacher")]
        [HttpDelete]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
                return BadRequest();
            }
            var existingData = await _parentService.GetParentAsync(id);
            if (existingData != null)
            {
                var result = await _parentService.DeleteAsync(id);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest("parent not found");
        }

        // Get Parent with student
        [MapToApiVersion("1.0")]
        [Route("parentwithstudent/{parentId}")]
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetParentAndStudent(int parentId)
        {
            _logger.LogInformation("Getting list of parent by ID:{id}", parentId);
            var result = await _parentService.GetParentWithStudent(parentId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
