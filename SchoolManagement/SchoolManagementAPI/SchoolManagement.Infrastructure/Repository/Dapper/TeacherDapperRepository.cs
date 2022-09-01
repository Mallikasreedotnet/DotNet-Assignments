using Dapper;
using SchoolManagement.Core.Entities;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.Dapper
{
    public class TeacherDapperRepository
    {
        private readonly IDbConnection _dbconnection;
        public TeacherDapperRepository(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            var command = "Insert Teacher(Email,Password,Fname,Lname,DOB,Phone,Mobile,Status,Last_login_date,Last_login_ip) Values(@Email,@Password,@Fname,@Lname,@DOB,@Phone,@Mobile,@Status,@Last_login_date,@Last_login_ip)";
            var result = await _dbconnection.ExecuteAsync(command, teacher);
            return teacher;
        }

        public async Task DeleteAsync(int teacherId)
        {
            var command = "Delete from Teacher where TeacherId=@TeacherId";
            await _dbconnection.ExecuteAsync(command, new { StudentId = teacherId });
        }

        public async Task<IEnumerable<Teacher>> GetTeacherAsync()
        {
            var query = "select * from Teacher";
            var teacherData = await _dbconnection.QueryAsync<Teacher>(query);
            return teacherData;
        }

        public async Task<Teacher> GetTeacherAsync(int teacherId)
        {
            var query = "Select * from Teacher where TeacherId=@TeacherId";
            return (await _dbconnection.QueryAsync<Teacher>(query, new { teacherId })).FirstOrDefault();
        }

        public async Task<Teacher> UpdateAsync(int teacherId, Teacher teacher)
        {
            teacher.TeacherId = teacherId;
            var command = "Update Teacher Set Email=@Email, Password=@Password, Fname=@Fname, Lname=@Lname, DOB=@DOB, Phone=@Phone, Mobile=@Mobile, Status=@Status, Last_login_date=@Last_login_date, Last_login_ip=@Last_login_ip, where TeacherId=@TeacherId";
            await _dbconnection.ExecuteAsync(command, teacher);
            return teacher;
        }
    }
}
