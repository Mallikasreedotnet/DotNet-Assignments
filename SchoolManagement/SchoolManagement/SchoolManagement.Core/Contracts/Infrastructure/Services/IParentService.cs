using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IParentService
    {
        Task<IEnumerable<ParentDto>> GetParentAsync();
        Task<ParentDto> GetParentAsync(int parentId);
        Task<Parent> GetParentByIdAsync(int parentId);
        Task<Parent> CreateParentAsync(Parent parent);
        Task<Parent> UpdateParentAsync(int parentId,Parent parent);
        Task<Parent> DeleteAsync(int parentId);
        Task<IEnumerable<ParentWithStudentDto>> GetParentWithStudent(int parentId);
    }
}
