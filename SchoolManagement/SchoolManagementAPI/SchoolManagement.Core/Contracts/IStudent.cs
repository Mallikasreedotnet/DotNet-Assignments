using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetStudentAsync();
        Task<Student> GetStudentAsync(int studentId);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateAsync(int studentId, Student student);
        Task<Student> DeleteAsync(int studentId);
    }
}
