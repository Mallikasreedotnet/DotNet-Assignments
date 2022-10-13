using JWT.Authentication.Server.Core.Contract.Infrastructure.Repositories;
using JWT.Authentication.Server.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT.Authentication.Server.Infrastructure.Repositories
{
    public class AuthStudentRepository : IStudentRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
       // private readonly IDbConnection _dbconnection;
        public AuthStudentRepository(SchoolManagementDbContext schoolDbContext/*, IDbConnection dbconnection*/)
        {
            _schoolDbContext = schoolDbContext;
           // _dbconnection = dbconnection;
        }

        public async Task<bool> RegisterStudent(Student student)
        {
            _schoolDbContext.Students.Add(student);
            await _schoolDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidateStudent(string email,string password)
        {
            return await _schoolDbContext.Students.AnyAsync(s => s.Email==email && s.Password==password);
        }
    }
}
