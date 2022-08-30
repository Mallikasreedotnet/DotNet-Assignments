using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ParentRepository : IParentRepository
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;

        public ParentRepository()
        {
            _schoolManagementDbContext =new SchoolManagementDbContext();
        }

        public async Task<IEnumerable<Parent>> GetParentAsync()
        {
           var data= await (from parent in _schoolManagementDbContext.Parents
                             select parent).ToListAsync();
            return data;
        }

        public async Task<Parent> GetParentAsync(int parentId)
        {
            return await _schoolManagementDbContext.Parents.FindAsync(parentId);
        }

        public async Task<Parent> CreateParentAsync(Parent parent)
        {

            _schoolManagementDbContext.Parents.Add(parent);
            await _schoolManagementDbContext.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent> UpdateAsync(int parentId, Parent parent)
        {
            var parentToBeUpdated = await GetParentAsync(parentId);
            parentToBeUpdated.Email = parent.Email;
            parentToBeUpdated.Password = parent.Password;
            parentToBeUpdated.Fname = parent.Fname;
            parentToBeUpdated.Lname = parent.Lname;
            parentToBeUpdated.Dob = parent.Dob;
            parentToBeUpdated.Phone = parent.Phone;
            parentToBeUpdated.Status = parent.Status;
            parentToBeUpdated.LastLoginDate = parent.LastLoginDate;
            parentToBeUpdated.LastLoginIp = parent.LastLoginIp;
            _schoolManagementDbContext.Parents.Update(parentToBeUpdated);
            await _schoolManagementDbContext.SaveChangesAsync();
            return parentToBeUpdated;
        }
        public async Task<Parent> DeleteAsync(int parentId)
        {
            var deletedToBeParent = await GetParentAsync(parentId);
            _schoolManagementDbContext.Parents.Remove(deletedToBeParent);
            await _schoolManagementDbContext.SaveChangesAsync();
            return deletedToBeParent;
        }
    }
}
