using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudentAsync();
        Task<StudentDto> GetStudentAsync(int studentId);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<StudentsWithClassDto> GetStudentsWithClass(int studentId);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateAsync(int studentId, Student student);
        Task<Student> DeleteAsync(int studentId);
       
    }
}
