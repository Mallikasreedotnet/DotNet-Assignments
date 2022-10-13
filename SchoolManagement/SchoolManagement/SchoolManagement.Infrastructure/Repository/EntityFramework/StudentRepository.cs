using Dapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
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
        public async Task<IEnumerable<StudentDto>> GetStudentAsync()
        {
            var query = "execute spGetStudents";
            var studentData = await _dbconnection.QueryAsync<StudentDto>(query);
            return studentData;
        }

        public async Task<StudentDto> GetStudentAsync(int studentId)
        {
            var query = "execute spGetStudentId @StudentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<StudentDto>(query, new { studentId }));
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var query = "select * from Student where StudentId=@StudentId";
            return (await _dbconnection.QueryFirstOrDefaultAsync<Student>(query, new { studentId }));
        }


        public async Task<Student> CreateStudentAsync(Student student)
        {
            _schoolDbContext.Students.Add(student);
            await _schoolDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            _schoolDbContext.Students.Update(student);
            await _schoolDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteAsync(int studentId)
        {
            var deletedToBeStudent = await GetStudentByIdAsync(studentId);
            _schoolDbContext.Students.Remove(deletedToBeStudent);
            await _schoolDbContext.SaveChangesAsync();
            return deletedToBeStudent;
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
                                                        GradeName = grade.GradeName,
                                                        ClassroomId = classRoom.ClassroomId,
                                                        Year = classRoom.Year,
                                                        Section = classRoom.Section,
                                                    }).FirstAsync();
            return studentWithClassroomRecord;
        }

        public async Task<bool> ValidateStudent(string email, string password)
        {
            var data=await _schoolDbContext.Students.AnyAsync(s => s.Email == email && s.Password == password);
            return data;
        }
    }
}
