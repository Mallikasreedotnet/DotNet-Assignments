using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class ParentRepository : IParentRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public ParentRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
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
            var query = "Select * from Parent where ParentId=@parentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Parent>(query, new { parentId }));

        }

        public async Task<IEnumerable<ParentDto>> GetParentWithStudent(int parentId)
        {
            var parentWithStudents = await (from parent in _schoolDbContext.Parents
                                            join student in _schoolDbContext.Students
                                            on parent.ParentId equals student.ParentId
                                            where parent.ParentId == parentId
                                            select new ParentDto
                                            {
                                                StudentId = student.StudentId,
                                                Lname = student.Lname,
                                                Fname = student.Fname,
                                            }).ToListAsync();
            return parentWithStudents;
        }

        public async Task<Parent> CreateParentAsync(Parent parent)
        {
            _schoolDbContext.Parents.Add(parent);
            await _schoolDbContext.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent> UpdateParentAsync(Parent parent)
        {
            _schoolDbContext.Parents.Update(parent);
            await _schoolDbContext.SaveChangesAsync();
            return parent;
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
