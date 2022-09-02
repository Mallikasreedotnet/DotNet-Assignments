using SchoolManagement.Infrastructure.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentAsync();
        Task<Student> GetStudentAsync(int studentId);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateAsync(int studentId, Student student);
        Task<Student> DeleteAsync(int studentId);
    }
}
