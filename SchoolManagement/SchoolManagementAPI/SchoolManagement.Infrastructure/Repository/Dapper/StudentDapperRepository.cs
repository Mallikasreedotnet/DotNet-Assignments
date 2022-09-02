using Dapper;
using SchoolManagement.Core.Entities;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.Dapper
{
    public class StudentDapperRepository
    {
        private readonly IDbConnection _dbconnection;
        public StudentDapperRepository(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            var command = "Insert Student(Email,Password,Fname,Lname,DOB,Phone,Mobile,ParentId,Status,Last_login_date,Last_login_ip,Date_of_join) Values(@Email,@Password,@Fname,@Lname,@DOB,@Phone,@Mobile,@ParentId,@Status,@Last_login_date,@Last_login_ip,@Date_of_join)";
            var result = await _dbconnection.ExecuteAsync(command, student);
            return student;
        }

        public async Task DeleteAsync(int studentId)
        {
            var command = "Delete from Student where StudentId=@StudentId";
            await _dbconnection.ExecuteAsync(command, new { StudentId = studentId });
        }

        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            var query = "select * from Student";
            var studentData = await _dbconnection.QueryAsync<Student>(query);
            return studentData;
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            var query = "Select * from Student where StudentId=@StudentId";
            return (await _dbconnection.QueryAsync<Student>(query, new { studentId })).FirstOrDefault();
        }

        public async Task<Student> UpdateAsync(int studentId, Student student)
        {
            student.StudentId = studentId;
            var command = "Update Student Set Email=@Email, Password=@Password, Fname=@Fname, Lname=@Lname, DOB=@DOB, Phone=@Phone, Mobile=@Mobile, ParentId=@ParentId, Status=@Status, Last_login_date=@Last_login_date, Last_login_ip=@Last_login_ip, Date_of_join=@Date_of_join  where StudentId=@StudentId";
            await _dbconnection.ExecuteAsync(command, student);
            return student;
        }
    }
}
