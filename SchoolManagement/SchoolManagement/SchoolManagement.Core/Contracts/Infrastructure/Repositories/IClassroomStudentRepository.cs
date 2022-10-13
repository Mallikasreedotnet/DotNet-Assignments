using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Repositories
{
    public interface IClassroomStudentRepository
    {
        Task<IEnumerable<ClassroomStudentDto>> GetClassroomStudentAsync();
        Task<ClassroomStudent> GetClassroomStudentByIdAsync(int classroomStudentId);
        Task<ClassroomStudentDto> GetClassroomStudentAsync(int classroomStudentId);
        Task<ClassroomStudent> CreateClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<ClassroomStudent> UpdateClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<ClassroomStudent> DeleteAsync(int classroomStudentId);
        Task<ClassroomStudent> GetNotRepeatedData(int classroomId, int studentId);

    }
}
