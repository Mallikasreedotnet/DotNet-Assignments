using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ParentRepository : IParent
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;

        public ParentRepository(SchoolManagementDbContext schoolManagementContext)
        {
            _schoolManagementDbContext = schoolManagementContext;
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
            return parentToBeUpdated;
        }
        public async Task<Parent> DeleteAsync(int parentId)
        {
            var deletedToBeParent = await GetParentAsync(parentId);
            _schoolManagementDbContext.Parents.Add(deletedToBeParent);
            await _schoolManagementDbContext.SaveChangesAsync();
            return deletedToBeParent;
        }
    }
}
