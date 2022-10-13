using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;

        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }
        public async Task<IEnumerable<ParentDto>> GetParentAsync()
        {
            return await _parentRepository.GetParentAsync();
        }

        public async Task<ParentDto> GetParentAsync(int parentId)
        {
            return await _parentRepository.GetParentAsync(parentId);
        }
        public async Task<Parent> GetParentByIdAsync(int parentId)
        {
            return await _parentRepository.GetParentByIdAsync(parentId);
        }

        public async Task<Parent> CreateParentAsync(Parent parent)
        {
            return await _parentRepository.CreateParentAsync(parent);
        }

        public async Task<IEnumerable<ParentWithStudentDto>> GetParentWithStudent(int parentId)
        {
            return await _parentRepository.GetParentWithStudent(parentId);
        }
        public async Task<Parent> UpdateParentAsync(int parentId,Parent parent)
        {
            var parentToBeUpdated = await GetParentByIdAsync(parentId);
            parentToBeUpdated.Email = parent.Email;
            parentToBeUpdated.Password = parent.Password;
            parentToBeUpdated.Fname = parent.Fname;
            parentToBeUpdated.Lname = parent.Lname;
            parentToBeUpdated.Dob = parent.Dob;
            parentToBeUpdated.Phone = parent.Phone;
            parentToBeUpdated.Mobile = parent.Mobile;
            parentToBeUpdated.Status = parent.Status;
            parentToBeUpdated.LastLoginDate = parent.LastLoginDate;
            parentToBeUpdated.LastLoginIp = parent.LastLoginIp;
            var data=await _parentRepository.UpdateParentAsync(parentToBeUpdated);
            return data;
        }

        public async Task<Parent> DeleteAsync(int parentId)
        {
           return await _parentRepository.DeleteAsync(parentId);
        }
    }
}
