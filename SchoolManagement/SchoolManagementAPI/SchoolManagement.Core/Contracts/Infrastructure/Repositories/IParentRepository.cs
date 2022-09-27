using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<ParentDto>> GetParentAsync();
        Task<ParentDto> GetParentAsync(int parentId);
        Task<Parent> GetParentByIdAsync(int parentId);
        Task<IEnumerable<ParentWithStudentDto>> GetParentWithStudent(int parentId);
        Task<Parent> CreateParentAsync(Parent parent);
        Task<Parent> UpdateParentAsync( Parent parent);
        Task<Parent> DeleteAsync(int parentId);
    }
}
