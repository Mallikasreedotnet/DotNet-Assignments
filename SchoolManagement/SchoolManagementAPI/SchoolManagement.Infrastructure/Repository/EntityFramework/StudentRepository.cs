using Dapper;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementDbContext _schoolDbContext;
        private readonly IDbConnection _dbconnection;
        public StudentRepository(SchoolManagementDbContext schoolDbContext, IDbConnection dbconnection)
        {
            _schoolDbContext = schoolDbContext;
            _dbconnection = dbconnection;
        }
        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            var query = "select * from Student";
            var studentData = await _dbconnection.QueryAsync<Student>(query);
            return studentData;
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            var query = "Select * from Student where Student_id=@StudentId";
            return (await _dbconnection.QueryAsync<Student>(query, new { studentId })).FirstOrDefault();
      
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            var studentData = new Student
            {
                Student_id = student.Student_id,
                Email = student.Email,
                Password = student.Password,
                Fname = student.Fname,
                Lname = student.Lname,
                Dob = student.Dob,
                Status = student.Status,
                Phone = student.Phone,
                Mobile = student.Mobile,
                Parent_id = student.Parent_id,
                DateOfJoin = student.DateOfJoin,
                LastLoginDate = student.LastLoginDate,
                LastLoginIp = student.LastLoginIp,
            };
            _schoolDbContext.Students.Add(studentData);
            await _schoolDbContext.SaveChangesAsync();
            return studentData;
        }
        public async Task<Student> UpdateAsync(int studentId,Student student)
        {
            var studentToBeUpdated = await GetStudentAsync(studentId);
            studentToBeUpdated.Email = student.Email;
            studentToBeUpdated.Password = student.Password;
            studentToBeUpdated.Fname = student.Fname;
            studentToBeUpdated.Lname = student.Lname;
            studentToBeUpdated.Dob = student.Dob;
            studentToBeUpdated.Phone = student.Phone;
            studentToBeUpdated.Mobile = student.Mobile;
            studentToBeUpdated.Parent_id = student.Parent_id;
            studentToBeUpdated.DateOfJoin = student.DateOfJoin;
            studentToBeUpdated.Status = student.Status;
            studentToBeUpdated.LastLoginDate = student.LastLoginDate;
            studentToBeUpdated.LastLoginIp = student.LastLoginIp;
            _schoolDbContext.Students.Update(studentToBeUpdated);
            await _schoolDbContext.SaveChangesAsync();
            return studentToBeUpdated;
        }

        public async Task<Student> DeleteAsync(int studentId)
        {
            var deletedToBeStudent = await GetStudentAsync(studentId);
            _schoolDbContext.Students.Remove(deletedToBeStudent);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeStudent;
        }
    }
}
