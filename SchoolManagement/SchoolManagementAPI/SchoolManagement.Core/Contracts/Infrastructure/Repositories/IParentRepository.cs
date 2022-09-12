using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetParentAsync();
        Task<Parent> GetParentAsync(int parentId);
        Task<ParentDto> GetParentWithStudent(int parentId);
        Task<Parent> CreateParentAsync(Parent parent);
        Task<Parent> UpdateParentAsync(int parentId, Parent parent);
        Task<Parent> DeleteAsync(int parentId);
    }
}
