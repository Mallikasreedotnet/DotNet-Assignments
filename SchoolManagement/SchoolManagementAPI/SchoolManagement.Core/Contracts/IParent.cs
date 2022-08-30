using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts
{
    public interface IParent
    {
        Task<IEnumerable<Parent>> GetParentAsync();
        Task<Parent> GetParentAsync(int id);
        Task<Parent> CreateParentAsync(Parent parent);
        Task<Parent> UpdateAsync(int parentId, Parent parent);
        Task<Parent> DeleteAsync(int id);
    }
}
