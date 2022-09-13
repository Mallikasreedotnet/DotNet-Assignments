using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Data;
using System.Data;
using SchoolManagementDbContext = SchoolManagement.Infrastructure.Data.SchoolManagementDbContext;

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
            var query = "Select * from Student where StudentId=@StudentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Student>(query, new { studentId }));
      
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            //var studentData = new Student
            //{
            //    StudentId = student.StudentId,
            //    Email = student.Email,
            //    Password = student.Password,
            //    Fname = student.Fname,
            //    Lname = student.Lname,
            //    Dob = student.Dob,
            //    Status = student.Status,
            //    Phone = student.Phone,
            //    Mobile = student.Mobile,
            //    ParentId = student.ParentId,
            //    DateOfJoin = student.DateOfJoin,
            //    LastLoginDate = student.LastLoginDate,
            //    LastLoginIp = student.LastLoginIp,
            //};
            _schoolDbContext.Students.Add(student);
            await _schoolDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<StudentsWithClassDto> GetStudentsWithClass(int studentId)
        {
            var studentWithClassroomRecord = await (from student in _schoolDbContext.Students
                                                    join classRoomStudent in _schoolDbContext.ClassroomStudents
                                                    on student.StudentId equals classRoomStudent.StudentId
                                                    join classRoom in _schoolDbContext.Classrooms
                                                    on classRoomStudent.ClassroomId equals classRoom.ClassroomId
                                                    join grade in _schoolDbContext.Grades
                                                    on classRoom.GradeId equals grade.GradeId
                                                    where student.StudentId == studentId
                                                    select new StudentsWithClassDto
                                                    {
                                                        Fname = student.Fname,
                                                        Lname = student.Lname,
                                                        GradeName = grade.Name,
                                                        ClassroomId = classRoom.ClassroomId,
                                                    }).FirstAsync();
              return studentWithClassroomRecord;
           
        }
        public async Task<Student> UpdateAsync(Student student)
        {
            _schoolDbContext.Students.Update(student);
            await _schoolDbContext.SaveChangesAsync();
            return student;
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
