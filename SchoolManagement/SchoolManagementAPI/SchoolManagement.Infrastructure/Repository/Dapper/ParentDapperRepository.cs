using Dapper;
using SchoolManagement.Core.Entities;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.Dapper
{
    public class ParentDapperRepository
    {
        private readonly IDbConnection _dbconnection;
        public ParentDapperRepository(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<Parent> CreateParentAsync(Parent parent)
        {
            var command = "Insert Parent(Email,Password,Fname,Lname,DOB,Phone,Mobile,Status,Last_login_date,Last_login_ip) Values(@Email,@Password,@Fname,@Lname,@DOB,@Phone,@Mobile,@Status,@Last_login_date,@Last_login_ip)";
            var result = await _dbconnection.ExecuteAsync(command, parent);
            return parent;
        }

        public async Task DeleteAsync(int parentId)
        {
            var command = "Delete from Parent where ParentId=@ParentId";
            await _dbconnection.ExecuteAsync(command,new { ParentId = parentId });
        }

        public async Task<IEnumerable<Parent>> GetParentAsync()
        {
            var query = "select * from Parent";
            var parentData = await _dbconnection.QueryAsync<Parent>(query);
            return parentData;
        }

        public async Task<Parent> GetParentAsync(int parentId)
        {
            var query = "Select * from Parent where ParentId=@ParentId";
            return (await _dbconnection.QueryAsync<Parent>(query, new { parentId })).FirstOrDefault();
        }

        public async Task<Parent> UpdateAsync(int parentId, Parent parent)
        {
            parent.ParentId = parentId;
            var command = "Update Parent Set Email=@Email, Password=@Password, Fname=@Fname, Lname=@Lname, DOB=@DOB, Phone=@Phone, Mobile=@Mobile, Status=@Status, Last_login_date=@Last_login_date, Last_login_ip=@Last_login_ip where ParentId=@ParentId";
            await _dbconnection.ExecuteAsync(command, parent);
            return parent;
        }
    }
}
