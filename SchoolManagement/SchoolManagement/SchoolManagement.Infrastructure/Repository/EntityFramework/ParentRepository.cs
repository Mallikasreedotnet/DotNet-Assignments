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

        public async Task<IEnumerable<ParentDto>> GetParentAsync()
        {
            var query = "select * from Parent";
            var parentData = await _dbconnection.QueryAsync<ParentDto>(query);
            return parentData;
        }

        public async Task<ParentDto> GetParentAsync(int parentId)
        {
            var query = "select * from Parent where ParentId=@parentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<ParentDto>(query, new { parentId }));
        }

        public async Task<Parent> GetParentByIdAsync(int parentId)
        {
            var query = "select * from Parent where ParentId=@parentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Parent>(query, new { parentId }));
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
            var deletedToBeParent = await GetParentByIdAsync(parentId);
            _schoolDbContext.Parents.Remove(deletedToBeParent);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeParent;
        }
        public async Task<IEnumerable<ParentWithStudentDto>> GetParentWithStudent(int parentId)
        {
            var parentWithStudents = await (from parent in _schoolDbContext.Parents
                                            join student in _schoolDbContext.Students
                                            on parent.ParentId equals student.ParentId
                                            where parent.ParentId == parentId
                                            select new ParentWithStudentDto
                                            {
                                                StudentId = student.StudentId,
                                                Lname = student.Lname,
                                                Fname = student.Fname,
                                            }).ToListAsync();
            return parentWithStudents;
        }

        public async Task<UserDto> GetUserDetails(string email, string user)
        {
            UserDto userResult = new UserDto();
            if (user == "Parent")
            {
                var data = await _schoolDbContext.Parents.FirstOrDefaultAsync(s => s.Email == email);
                userResult = new UserDto
                {
                    Email = data.Email,
                    Password = data.Password,
                    Fname = data.Fname,
                    Lname = data.Lname,
                    PasswordSalt = data.PasswordSalt,
                    Role = "Parent"
                };
            }
            if (user == "Student")
            {
                var studentdata = await _schoolDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
                userResult = new UserDto
                {
                    Email = studentdata.Email,
                    Password = studentdata.Password,
                    Fname = studentdata.Fname,
                    Lname = studentdata.Lname,
                    PasswordSalt = studentdata.PasswordSalt,
                    Role = "Student"
                };
            }
            if (user == "Teacher")
            {
                var teacherdata = await _schoolDbContext.Teachers.FirstOrDefaultAsync(s => s.Email == email);
                userResult = new UserDto
                {
                    Email = teacherdata.Email,
                    Password = teacherdata.Password,
                    Fname = teacherdata.Fname,
                    Lname = teacherdata.Lname,
                    PasswordSalt = teacherdata.PasswordSalt,
                    Role = "Teacher"
                };
            }
            return userResult;
        }
    }
}
