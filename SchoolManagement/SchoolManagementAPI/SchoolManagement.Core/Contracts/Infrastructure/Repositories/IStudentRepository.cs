using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudentAsync();
        Task<StudentDto> GetStudentAsync(int studentId);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<StudentsWithClassDto> GetStudentsWithClass(int studentId);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(int studentId);
        
    }
}
