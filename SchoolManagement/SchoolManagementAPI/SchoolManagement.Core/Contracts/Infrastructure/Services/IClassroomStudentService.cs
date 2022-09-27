using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IClassroomStudentService
    {
        Task<IEnumerable<ClassroomStudentDto>> GetClassroomStudentAsync();
        Task<ClassroomStudentDto> GetClassroomStudentAsync(int classroomStudentId);
        Task<ClassroomStudent> GetClassroomStudentByIdAsync(int classroomStudentId);
        Task<ClassroomStudent> CreateClassroomStudentAsync(ClassroomStudent classroomStudent);
        Task<ClassroomStudent> UpdateClassroomStudentAsync(int classroomStudentId,ClassroomStudent classroomStudent);
        Task<ClassroomStudent> DeleteAsync(int classroomStudentId);
        Task<ClassroomStudent> GetNotRepeatedData(int classroomId, int studentId);
    }
}
