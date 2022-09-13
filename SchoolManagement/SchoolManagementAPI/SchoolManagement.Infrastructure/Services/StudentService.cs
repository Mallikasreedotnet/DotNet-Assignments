using SchoolManagement.Core.Contracts.Infrastructure.Repositories;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
           return await _studentRepository.GetStudentAsync();
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
           return await _studentRepository.GetStudentAsync(studentId);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            return await _studentRepository.CreateStudentAsync(student);
        }

        public async Task<StudentsWithClassDto> GetStudentsWithClass(int studentId)
        {
            return await _studentRepository.GetStudentsWithClass(studentId);  
        }
        public async Task<Student> UpdateAsync(int studentId, Student student)
        {
            var studentToBeUpdated = await GetStudentAsync(studentId);
            studentToBeUpdated.Email = student.Email;
            studentToBeUpdated.Password = student.Password;
            studentToBeUpdated.Fname = student.Fname;
            studentToBeUpdated.Lname = student.Lname;
            studentToBeUpdated.Dob = student.Dob;
            studentToBeUpdated.Phone = student.Phone;
            studentToBeUpdated.Mobile = student.Mobile;
            studentToBeUpdated.ParentId = student.ParentId;
            studentToBeUpdated.DateOfJoin = student.DateOfJoin;
            studentToBeUpdated.Status = student.Status;
            studentToBeUpdated.LastLoginDate = student.LastLoginDate;
            studentToBeUpdated.LastLoginIp = student.LastLoginIp;
            var data = await _studentRepository.UpdateAsync(studentToBeUpdated);
            return data;
        }

        public async Task<Student> DeleteAsync(int studentId)
        {
           return await _studentRepository.DeleteAsync(studentId);
        }
    }
}
