using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetParentAsync();
        Task<Parent> GetParentAsync(int parentId);
        Task<Parent> CreateParentAsync(Parent parent);
        Task<Parent> UpdateAsync(int parentId, Parent parent);
        Task<Parent> DeleteAsync(int parentId);
    }
}
