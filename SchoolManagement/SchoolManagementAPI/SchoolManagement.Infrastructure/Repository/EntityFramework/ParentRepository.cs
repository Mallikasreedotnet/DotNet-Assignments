using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;
using System.Data.Common;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ParentRepository : IParentRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public ParentRepository(SchoolManagementDbContext schoolDbContext,IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Parent>> GetParentAsync()
        {
            var query = "select * from [Parent]";
            var parentData = await _dbconnection.QueryAsync<Parent>(query);
            return parentData;
        }

        public async Task<Parent> GetParentAsync(int parentId)
        {
            var query = "Select * from Parent where Parent_id=@parentId";
            return (await _dbconnection.QueryAsync<Parent>(query, new { parentId })).FirstOrDefault();
          
        }

        public async Task<Parent> CreateParentAsync(Parent parent)
        {
            _schoolDbContext.Parents.Add(parent);
            await _schoolDbContext.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent> UpdateParentAsync(int parentId, Parent parent)
        {
            var parentToBeUpdated = await GetParentAsync(parentId);
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
            _schoolDbContext.Parents.Update(parentToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return parentToBeUpdated;
        }
        public async Task<Parent> DeleteAsync(int parentId)
        {
            var deletedToBeParent = await GetParentAsync(parentId);
            _schoolDbContext.Parents.Remove(deletedToBeParent);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeParent;
        }
    }
}
