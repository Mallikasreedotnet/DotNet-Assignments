using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repository.EntityFramework
{
    public class StudentRepository : IStudent
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;
        public StudentRepository(SchoolManagementDbContext schoolManagementDbContext)
        {
            _schoolManagementDbContext = schoolManagementDbContext;
        }
        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            var studentData = await (from student in _schoolManagementDbContext.Students
                                 select student).ToListAsync();
            return studentData;
        }
        public async Task<Student> GetStudentAsync(int studentId)
        {
            return await _schoolManagementDbContext.Students.FindAsync(studentId);
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            var studentData = new Student
            {
                StudentId = student.StudentId,
                Email = student.Email,
                Password = student.Password,
                Fname = student.Fname,
                Lname = student.Lname,
                Dob = student.Dob,
                Status = student.Status,
                Phone = student.Phone,
                Mobile = student.Mobile,
                ParentId = student.ParentId,
                DateOfJoin = student.DateOfJoin,
                LastLoginDate = student.LastLoginDate,
                LastLoginIp = student.LastLoginIp,
            };
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
            studentToBeUpdated.Status = student.Status;
            studentToBeUpdated.LastLoginDate = student.LastLoginDate;
            studentToBeUpdated.LastLoginIp = student.LastLoginIp;
            _schoolManagementDbContext.Students.Update(studentToBeUpdated);
            return studentToBeUpdated;
        }

        public async Task<Student> DeleteAsync(int studentId)
        {
            var deletedToBeStudent = await GetStudentAsync(studentId);
            _schoolManagementDbContext.Students.Add(deletedToBeStudent);
            await _schoolManagementDbContext.SaveChangesAsync();
            return deletedToBeStudent;
        }
    }
}
